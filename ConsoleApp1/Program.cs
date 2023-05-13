using Checked;
using Enum;
using Extern;
using FixedUnsafe;
using Interface;
using Lock;
using Readonly;
using System;
using Unchecked;
using Virtual;
using Volatile;
using Yield;

namespace ConsoleApp1
{
    class Program
    {
        /*
            IAsyncEnumerable<string> elements = MyAsyncIteratorMethod();
            await foreach (string element in elements)
            {
               // ...
            }
        */

        static void Main(string[] args)
        {
            new Out().Run();
            new In().Run();
            new Ref().Run();


            #region Implicit Explicit Operator
            var d = new Digit(7); // structure

            byte number = d; // необходим implicit
            Console.WriteLine(number);  // output: 7

            Digit digit = (Digit)number; // structure. необходим explicit
            Console.WriteLine(digit);  // output: 7
            #endregion

            #region This
            var a = new Fraction(5, 4);
            var b = new Fraction(1, 2);
            var op1 = -a;
            var op2 = a + b;
            var op3 = a - b;
            var op4 = a * b;
            var op5 = a / b;
            //var op6 = a + 1;
            var op6 = a + a;
            
            var this_ = new This();
            //this_.Foo(this);

            this_.Foo();

            var stringCollection = new SampleCollection<string>();
            stringCollection[0] = "Hello, World";
            var this1 = stringCollection[0];
            var stringCollection2 = new SampleCollection2<string>();
            stringCollection2.Add("Hello, World");
            var this2 = stringCollection2[0];
            var stringCollection3 = new SampleCollection3<string>();
            stringCollection3[0] = "Hello, World.";
            var this3 = stringCollection3[0];
            #endregion

            #region Yield
            PowersOf2.Main();
            GalaxyClass.ShowGalaxies();
            #endregion

            #region Virtual
            TestClass.Main();
            #endregion

            #region Volatile
            WorkerThreadExample.Main();
            #endregion

            #region Default
            new Default().Main();
            #endregion

            #region Lock
            AccountTest.Main();
            #endregion

            #region External
            //ExternTest.Main();
            #endregion

            #region
            MainClass.Main();
            #endregion

            #region Fixed Unsafe
            FixedUnsafe_.FixedSpanExample();
            UnsafeCode_PointerTypes_FunctionPointers.Ex2();
            UnsafeCode_PointerTypes_FunctionPointers.Ex3();
            UnsafeCode_PointerTypes_FunctionPointers.AccessEmbeddedArray();
            UnsafeCode_PointerTypes_FunctionPointers.UnsafeCopyArrays();
            #endregion

            #region Readonly
            // https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/proposals/csharp-7.2/readonly-ref
            SamplePoint.Main();
            #endregion

            #region Enum
            FlagsEnumExample.Main();
            EnumConversionExample.Main();
            #endregion

            #region Checked
            OverFlowTest.Main();
            #endregion

            #region Unchecked
            UncheckedDemo.Main();
            #endregion

            #region
            #endregion

            #region
            #endregion

            #region
            #endregion

            #region
            #endregion

            #region
            #endregion
            Console.WriteLine("Hello World!");
            Console.ReadLine();
        }
    }
}
