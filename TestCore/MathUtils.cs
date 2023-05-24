namespace TestCore
{
    public static class MathUtils
    {
        public static int Reverse(int number)
        {
            var result = 0;
            while (number > 0) 
            {
                result = result*10 + number%10;
                number /= 10;
            }
            return result;
        }

        public static bool IsPalindrome(int number)
        {
            var reversedNumber = Reverse(number);

            return reversedNumber == number;
        }
    }
}