using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace TestCore
{
    public class MemoryFileDataStorage<TItem>: IDataStorage<TItem>, IDisposable
        where TItem : class
    {
        private IDictionary<Guid, TItem> _items;
        private string _dataFileName;

        public MemoryFileDataStorage(string dataFileName)
        {
            _dataFileName = dataFileName;
            LoadData(_dataFileName);
        }

        private void LoadData(string dataFileName)
        {
            if (File.Exists(dataFileName))
            {
                try
                {
                    var source = File.ReadAllText(dataFileName);
                    _items = JsonConvert.DeserializeObject<IDictionary<Guid, TItem>>(source);
                }
                catch (Exception e)
                {
                    throw new Exception($"Error while loading data. {e.Message}");
                }
            }
            else
            {
                _items = new Dictionary<Guid, TItem>();
            }
        }

        private void SaveData(string dataFileName)
        {
            if (_items != null)
            {
                try
                {
                    var json = JsonConvert.SerializeObject(_items, Formatting.Indented);
                    File.WriteAllText(dataFileName, json);
                }
                catch (Exception e)
                {
                    throw new Exception($"Error while saving data. {e.Message}");
                }
            }
        }

        public void SaveItem(Guid id, TItem item)
        {
            _items[id] = item;
        }

        public TItem GetItem(Guid id)
        {
            if (_items.ContainsKey(id))
            {
                return _items[id];
            }

            return null;
        }

        public IDictionary<Guid, TItem> GetItems()
        {
            return _items;
        }

        public void Dispose()
        {
            SaveData(_dataFileName);
        }
    }
}