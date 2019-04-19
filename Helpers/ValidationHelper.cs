using System;
using System.Threading;
using System.Threading.Tasks;

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
    }
}