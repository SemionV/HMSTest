using System;
using System.Collections.Generic;
using TestCore.Domain;

namespace TestCore
{
    public class Transform
    {
        private readonly IDataStorage<PalindromeCalculationItem> _itemStorage;

        public Transform(IDataStorage<PalindromeCalculationItem> itemStorage)
        {
            _itemStorage = itemStorage;
        }

        public PalindromeCalculationItem Palindrome(int input)
        {
            var item = CalculatePalindrome(input);

            var id = Guid.NewGuid();
            _itemStorage.SaveItem(id, item);

            return item;
        }

        public PalindromeCalculationItem PalindromeWithoutSave(int input)
        {
            var item = CalculatePalindrome(input);

            return item;
        }

        public IDictionary<Guid, PalindromeCalculationItem> GetAllCalculationItems()
        {
            return _itemStorage.GetItems();
        }

        private static PalindromeCalculationItem CalculatePalindrome(int input)
        {
            var counter = 0;
            var palindrome = input;

            while (!MathUtils.IsPalindrome(palindrome))
            {
                var reversedNumber = MathUtils.Reverse(palindrome);
                palindrome += reversedNumber;

                counter++;

                if (palindrome > 1000000000)
                {
                    palindrome = -1;
                    break;
                }
            }

            return new PalindromeCalculationItem
            {
                Input = input,
                Result = palindrome,
                Cycles = counter
            };;
        }
    }
}