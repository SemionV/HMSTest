using System;
using System.Collections.Generic;

namespace TestCore
{
    public interface IDataStorage<TItem>
    {
        void SaveItem(Guid id, TItem item);
        TItem GetItem(Guid id);
        IDictionary<Guid, TItem> GetItems();
    }
}