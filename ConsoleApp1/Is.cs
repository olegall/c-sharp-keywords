using System;

namespace ConsoleApp1
{
    class Is
    {
        static bool IsFirstSummerMonday(DateTime date) => date is { Month: 6, Day: /*<=*/ 7, DayOfWeek: DayOfWeek.Monday };

        public void Run() 
        {

        }
    }
}
