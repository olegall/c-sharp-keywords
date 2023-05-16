using System;

namespace ConsoleApp1
{
    public class Base { }

    public class Derived : Base { }

    class Is
    {
        private void _1() 
        {
            object b = new Base();
            var a1 = b is Base;  // output: True
            var a2 = b is Derived;  // output: False

            object d = new Derived();
            var a3 = d is Base;  // output: True
            var a4 = d is Derived; // output: True

            int i = 27;
            var a5 = i is System.IFormattable;  // output: True

            object iBoxed = i;
            var a6 = iBoxed is int;  // output: True
            var a7 = iBoxed is long;  // output: False
        }
        
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
                //return;
            }

            //object result = null;
            //if (result is not null)
            //{
            //    Console.WriteLine(result.ToString());
            //}

            _1();
        }
    }
}
