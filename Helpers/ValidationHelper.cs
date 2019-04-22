using System;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;

namespace RestaurantSearch.UITests.Helpers
{
    public static class ValidationHelper
    {
        public static async Task<bool> ValidateAsync<T>(Func<Task<T>> dataDelegate,
            Func<T, bool> validationDelegate,
            TimeSpan interval, int retry = 5)
        {
            for (int i = 0; i < retry; i++)
            {
                Thread.Sleep(interval);

                var data = await dataDelegate();
                if (validationDelegate(data))
                    return true;
                else
                    Console.WriteLine($"Validation criteria not satisfied, retrying; attempt {i + 1}");
            }

            Console.WriteLine($"Validation; criteria was not met. Max retries reached {retry}");

            return false;
        }

        private static string AssertionExceptionMessage<T>(T actual, T expected) => $"Validation failed: '{actual}' doesn't contain or equal '{expected}'.";

        public static void AssertTrue(string actualResult, string expectedResult) => Assert.True(actualResult.ContainsString(expectedResult, StringComparison.OrdinalIgnoreCase), AssertionExceptionMessage(actualResult, expectedResult));

        public static void AssertEqual<T>(T actualResult, T expectedResult) => Assert.AreEqual(actualResult, expectedResult, AssertionExceptionMessage(actualResult, expectedResult));

        public static void AssertNotEqual<T>(T actualResult, T expectedResult) => Assert.AreNotEqual(actualResult, expectedResult, AssertionExceptionMessage(actualResult, expectedResult));
    }
}