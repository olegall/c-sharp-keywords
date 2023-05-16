using System;

namespace ConsoleApp1
{
    public class CheckedUnchecked
    {
        // Set maxIntValue to the maximum value for integers.
        static int maxIntValue = 2147483647;

        // Using a checked expression.
        static int CheckedMethod()
        {
            int z = 0;
            try
            {
                // The following line raises an exception because it is checked.
                z = checked(maxIntValue + 10);
            }
            catch (OverflowException e)
            {
                // The following line displays information about the error.
                Console.WriteLine("CHECKED and CAUGHT:  " + e.ToString());
            }
            // The value of z is still 0.
            return z;
        }

        // Using an unchecked expression.
        static int UncheckedMethod()
        {
            int z = 0;
            try
            {
                // The following calculation is unchecked and will not
                // raise an exception.
                z = maxIntValue + 10;
            }
            catch (OverflowException e)
            {
                // The following line will not be executed.
                Console.WriteLine("UNCHECKED and CAUGHT:  " + e.ToString());
            }
            // Because of the undetected overflow, the sum of 2147483647 + 10 is
            // returned as -2147483639.
            return z;
        }


        public void _1() // Microsoft
        {
            uint a = uint.MaxValue;

            var a1 = a + 3;

            unchecked
            {
                var a2 = a + 3;  // output: 2. Результат такой же как выше (без unchecked)
            }

            try
            {
                checked
                {
                    var a2 = a + 3;
                }
            }
            catch (OverflowException e)
            {
                var a2 = e.Message;  // output: Arithmetic operation resulted in an overflow.
            }

            //checked
            //{
            //    var a2 = a + 3; // OverflowException
            //}
        }

        public void _2() // Microsoft
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

        public void _3() // Microsoft
        {
            int Multiply(int a, int b) => a * b;

            int factor = 2;

            try
            {
                checked
                {
                    var a1 = Multiply(factor, int.MaxValue);  // output: -2
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
                    var a1 = Multiply(factor, factor * int.MaxValue);
                }
            }
            catch (OverflowException e)
            {
                var a1 = e.Message;  // output: Arithmetic operation resulted in an overflow.
            }
        }

        public void Run()
        {
            _1();
            _2();
            _3();

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

            Console.WriteLine("\nCHECKED output value is: {0}", CheckedMethod());
            Console.WriteLine("UNCHECKED output value is: {0}", UncheckedMethod());
        }
    }
}
