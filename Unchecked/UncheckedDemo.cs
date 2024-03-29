﻿using System;

namespace ConsoleApp1
{
    public class CheckedUnchecked
    {
        public void Microsoft1() 
        {
            uint a = uint.MaxValue;

            unchecked
            {
                var a1 = a + 3;  // output: 2
            }

            try
            {
                checked
                {
                    var a1 = a + 3;
                }
            }
            catch (OverflowException e)
            {
                var a1 = e.Message;  // output: Arithmetic operation resulted in an overflow.
            }

            var a2 = a + 3;
        }

        public void Microsoft2()
        {
            double a = double.MaxValue;

            int b = unchecked((int)a);
            Console.WriteLine(b);  // output: -2147483648

            try
            {
                b = checked((int)a);
            }
            catch (OverflowException e)
            {
                Console.WriteLine(e.Message);  // output: Arithmetic operation resulted in an overflow.
            }
        }

        public void Microsoft3() 
        {
            int Multiply(int a, int b) => a * b;

            int factor = 2;

            try
            {
                checked
                {
                    Console.WriteLine(Multiply(factor, int.MaxValue));  // output: -2
                }
            }
            catch (OverflowException e)
            {
                var a1 = e.Message;
            }

            try
            {
                checked
                {
                    Console.WriteLine(Multiply(factor, factor * int.MaxValue));
                }
            }
            catch (OverflowException e)
            {
                Console.WriteLine(e.Message);  // output: Arithmetic operation resulted in an overflow.
            }
        }

        public void Run()
        {
            Microsoft1();
            Microsoft2();
            Microsoft3();

            // int.MaxValue is 2,147,483,647.
            const int ConstantMax = int.MaxValue;
            int int1;
            int int2;
            int variableMax = 2147483647;

            // The following statements are checked by default at compile time. They do not
            // compile.
            //int1 = 2147483647 + 10;
            //int1 = ConstantMax + 10;

            // To enable the assignments to int1 to compile and run, place them inside
            // an unchecked block or expression. The following statements compile and
            // run.
            unchecked
            {
                int1 = 2147483647 + 10; // исключения нет. int = -2147483639
            }
            int1 = unchecked(ConstantMax + 10);

            // The sum of 2,147,483,647 and 10 is displayed as -2,147,483,639.
            Console.WriteLine(int1);

            // The following statement is unchecked by default at compile time and run
            // time because the expression contains the variable variableMax. It causes
            // overflow but the overflow is not detected. The statement compiles and runs.
            int2 = variableMax + 10;

            // Again, the sum of 2,147,483,647 and 10 is displayed as -2,147,483,639.
            Console.WriteLine(int2);

            // To catch the overflow in the assignment to int2 at run time, put the
            // declaration in a checked block or expression. The following
            // statements compile but raise an overflow exception at run time.
            checked
            {
                //int2 = variableMax + 10;
            }
            //int2 = checked(variableMax + 10);

            // Unchecked sections frequently are used to break out of a checked
            // environment in order to improve performance in a portion of code
            // that is not expected to raise overflow exceptions.
            checked
            {
                // Code that might cause overflow should be executed in a checked
                // environment.
                unchecked
                {
                    // This section is appropriate for code that you are confident
                    // will not result in overflow, and for which performance is
                    // a priority.
                }
                // Additional checked code here.
            }
        }
    }
}
