using System;

namespace ConsoleApp1
{

    class Is
    {
        static bool IsFirstSummerMonday(DateTime date) => date is { Month: 6, Day: /*<=*/ 7, DayOfWeek: DayOfWeek.Monday };

        public void Run() 
        {
            int i = 34;
            object iBoxed = i;
            int? jNullable = 42;
            if (iBoxed is int a && jNullable is int b)
            {
                Console.WriteLine(a + b);  // output 76
            }

            object input = null;
            if (input is null)
            {
                return;
            }

            //object result = null;
            //if (result is not null)
            //{
            //    Console.WriteLine(result.ToString());
            //}
        }
    }
}
