using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class IsAsTypeofCast
    {
        public class Is
        {
            public class Base { }

            public class Derived : Base { }

            public static class IsOperatorExample
            {
                public static void Main1_()
                {
                    object b = new Base();
                    var a1 = b is Base;  // output: True
                    var a2 = b is Derived;  // output: False

                    object d = new Derived();
                    var a3 = d is Base;  // output: True
                    var a4 = d is Derived; // output: True
                }
            }

            public void _1()
            {
                int i = 27;
                var a1 = i is System.IFormattable;  // output: True

                object iBoxed = i;
                var a2 = iBoxed is int;  // output: True
                var a3 = iBoxed is long;  // output: False
            }

            public void _2()
            {
                int i = 23;
                object iBoxed = i;
                int? jNullable = 7;
                if (iBoxed is int a && jNullable is int b)
                {
                    var a1 = a + b;  // output 30
                }
            }
        }

        public class As 
        {
            public void _1()
            {
                IEnumerable<int> numbers = new[] { 10, 20, 30 };
                IList<int> indexable = numbers as IList<int>;
                if (indexable != null)
                {
                    //Console.WriteLine(indexable[0] + indexable[indexable.Count - 1]);  // output: 40
                }
            }
        }

        public class Typeof 
        {
            void PrintType<T>() => Console.WriteLine(typeof(T));

            public void Run() 
            {
                Console.WriteLine(typeof(List<string>));
                PrintType<int>();
                PrintType<System.Int32>();
                PrintType<Dictionary<int, char>>();

                // Output:
                // System.Collections.Generic.List`1[System.String]
                // System.Int32
                // System.Int32
                // System.Collections.Generic.Dictionary`2[System.Int32,System.Char]
            }
        }

        public class Cast
        {
            public void _1()
            {
                IEnumerable<int> numbers = new int[] { 10, 20, 30 };
                IList<int> list = (IList<int>)numbers;
                var a1 = list.Count;  // output: 3
                var a2 = list[1];  // output: 20
            }
        }

        public void Run() 
        {
            var is_ = new Is();
            Is.IsOperatorExample.Main1_();
            is_._1();
            is_._2();

            var as_ = new As();
            as_._1();

            var typeof_ = new Typeof();
            typeof_.Run();

            var cast = new Cast();
            cast._1();
        }
    }
}
