using System;
using System.Collections.Generic;

namespace DictCol
{
    public class DictPractice
    {
        static void Test()
        {
            Dictionary<int, string> dict1 = new Dictionary<int, string>();

            var dict2 = new Dictionary<string, string>();

            var states = new Dictionary<string, string>()
            {
                { "UP", "Uttar Pradesh" },
                { "HR", "Haryana" },
                { "KN", "Karnataka" }
            };

            states.Add("BH", "Bihar");
            // states.Add("UP", "Uttar Pradesh"); // ArgumentException - already exists
            states.TryAdd("HR", "Haryana Temp");

            if (states.ContainsKey("HR"))
            {
                // do something
            }

        }
    }
}
