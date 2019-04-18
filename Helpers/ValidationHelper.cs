using System;
using System.Threading;

namespace RestaurantSearch.UITests.Helpers
{
    public class ValidationHelper
    {
        public string Validate(Func<string> dataDelegate,
            string validationDelegate,
            TimeSpan interval, int retry = 5)
        {
            for (int i = 0; i < retry; i++)
            {
                Thread.Sleep(interval);

                var data =  dataDelegate();
                if (!data.Contains(validationDelegate))
                    return data;
                else
                    Console.WriteLine($"Validation criteria not satisfied, retrying; attempt {i + 1}");
            }

            Console.WriteLine($"Validation; criteria was not met. Max retries reached {retry}");

            return "fail";
        }
    }
}