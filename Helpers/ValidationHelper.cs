using System;
using System.Threading;
using System.Threading.Tasks;

namespace RestaurantSearch.UITests.Helpers
{
    public static class ValidationHelper
    {
        public static async Task<string> ValidateAsync<T>(Func<Task<T>> dataDelegate,
            Func<T> validationDelegate,
            TimeSpan interval, int retry = 5)
        {
            for (int i = 0; i < retry; i++)
            {
                Thread.Sleep(interval);

                var data = await dataDelegate();
                if (!dataDelegate.ToString().Contains(validationDelegate.ToString()))
                    return data.ToString();
                else
                    Console.WriteLine($"Validation criteria not satisfied, retrying; attempt {i + 1}");
            }

            Console.WriteLine($"Validation; criteria was not met. Max retries reached {retry}");

            return $"Validation; criteria was not met. Max retries reached {retry}";
        }
    }
}