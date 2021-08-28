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
            // что ближе - out/ref, in/out ... ?
            // какая разница - просто ссылочный тип, ref или out? во всех случаях влияние оказывается на внешний объект
            #region Out
            int param;  // вызовется public void __2(out int param). не обязательно присваивать
            int? paramNullable = 1; // вызовется public void __2(out int? param)

            var _out = new Out();
            _out.__1(out param); // обязательно out, обязательно int param - назван так же
            _out.__1(out paramNullable); // обязательно out, обязательно int param - назван так же
            var a1Out = _out.__2(out param); // и вернёт значение и передаст по ссылке
            _out.__3();
            #endregion

            #region In
            int paramIn = 10;  // обязательно присвоить
            int? paramNullableIn = 1; // вызовется public void __2(out int? param)

            var _in = new In();
            _in.__1__(in paramIn); // обязательно out, обязательно int param - назван так же
            _in.__1__(paramIn); // какая разница - вызывать с in или без?

            _in.__2__(in paramNullableIn); // обязательно out, обязательно int param - назван так же
            var a1In = _in.__3__(in paramIn); // и вернёт значение и передаст по ссылке


            _in.Method(5); // OK, temporary variable created.
            //Method(5L); // CS1503: no implicit conversion from long to int
            _in.Method((int)5L);
            short s = 0;
            _in.Method(s); // OK, temporary int created with the value 0
            //_in.Method(in s); // CS1503: cannot convert from in short to in int
            //_in.Method(in (int)s);
            int i = 42;
            _in.Method(i); // passed by readonly reference
            _in.Method(in i); // passed by readonly reference, explicitly using `in`


            _in.Method(5); // Calls overload passed by value
            //_in.Method(5L); // CS1503: no implicit conversion from long to int

            _in.Method(s); // Calls overload passed by value.
            //_in.Method(in s); // CS1503: cannot convert from in short to in int

            _in.Method(i); // Calls overload passed by value
            _in.Method(in i); // passed by readonly reference, explicitly using `in`
            #endregion

            #region Ref
            int paramRef = 0;  // вызовется public void __2(out int param). обязательно присваивать
            int? paramNullableRef = 1; // вызовется public void __2(out int? param)

            var _ref = new Ref();
            _ref.__1(ref paramRef); // обязательно out, обязательно int param - назван так же
            _ref.__1(ref paramNullableRef); // обязательно out, обязательно int param - назван так же
            var a1Ref = _ref.__2(ref paramRef); // и вернёт значение и передаст по ссылке
                                                //_ref.__3();
            #endregion

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
