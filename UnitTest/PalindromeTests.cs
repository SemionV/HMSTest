using System;
using Moq;
using NUnit.Framework;
using TestCore;
using TestCore.Domain;

namespace UnitTest
{
    [TestFixture]
    public class PalindromeTests
    {
        [TestCase(12, 21)]
        [TestCase(197, 791)]
        [TestCase(121, 121)]
        [TestCase(12345, 54321)]
        [TestCase(10001, 10001)]
        public void ReverseInt(int input, int expected)
        {
            var result = MathUtils.Reverse(input);

            Assert.AreEqual(expected, result);
        }

        [TestCase(121, true)]
        [TestCase(197, false)]
        [TestCase(1234554321, true)]
        [TestCase(100001, true)]
        [TestCase(10001, true)]
        [TestCase(34543, true)]
        public void IsPalindrome(int input, bool expected)
        {
            var result = MathUtils.IsPalindrome(input);

            Assert.AreEqual(expected, result);
        }

        [TestCase(28, 121)]
        [TestCase(51, 66)]
        [TestCase(11, 11)]
        [TestCase(607, 4444)]
        [TestCase(196, -1)]
        public void Palindrome(int input, int expected)
        {
            var storageMock = new Mock<IDataStorage<PalindromeCalculationItem>>();
            storageMock.Setup(p => p.SaveItem(It.IsAny<Guid>(), It.IsAny<PalindromeCalculationItem>()));

            var transform = new Transform(storageMock.Object);

            var calculationItem = transform.Palindrome(input);

            Assert.AreEqual(expected, calculationItem.Result);
        }
    }
}
