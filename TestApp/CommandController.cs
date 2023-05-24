using System;
using TestCore;

namespace TestApp
{
    public class CommandController
    {
        private readonly Transform _transform;

        public CommandController(Transform transform)
        {
            _transform = transform;
        }

        public void CalculatePalindromeWithoutSave(int input)
        {
            try
            {
                var calculationItem = _transform.PalindromeWithoutSave(input);

                Console.WriteLine($"Palindrome of {input}: {calculationItem.Result}. Number of Cycles used: {calculationItem.Cycles}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public void CalculatePalindrome(int input)
        {
            try
            {
                var calculationItem = _transform.Palindrome(input);

                Console.WriteLine($"Palindrome of {input}: {calculationItem.Result}. Number of Cycles used: {calculationItem.Cycles}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public void DisplayData()
        {
            try
            {
                var items = _transform.GetAllCalculationItems();
                if (items != null && items.Keys.Count > 0)
                {
                    Console.WriteLine("There are following calculations were made:");

                    foreach (var itemPair in items)
                    {
                        var item = itemPair.Value;
                        Console.WriteLine($"Input: {item.Input}, Result: {item.Result}, Cycles: {item.Cycles}");
                    }
                }
                else
                {
                    Console.WriteLine("There are no calculations were made yet.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}