using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            // что ближе - out/ref, in/out ... ?
            // какая разница - просто ссылочный тип, ref или out? во всех случаях влияние оказывается на внешний объект
            #region out
            int param;  // вызовется public void __2(out int param). не обязательно присваивать
            int? paramNullable = 1; // вызовется public void __2(out int? param)

            var _out = new Out();
            _out.__1(out param); // обязательно out, обязательно int param - назван так же
            _out.__1(out paramNullable); // обязательно out, обязательно int param - назван так же
            var a1Out = _out.__2(out param); // и вернёт значение и передаст по ссылке
            _out.__3();
            #endregion

            #region in
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

            #region ref
            int paramRef = 0;  // вызовется public void __2(out int param). обязательно присваивать
            int? paramNullableRef = 1; // вызовется public void __2(out int? param)

            var _ref = new Ref();
            _ref.__1(ref paramRef); // обязательно out, обязательно int param - назван так же
            _ref.__1(ref paramNullableRef); // обязательно out, обязательно int param - назван так же
            var a1Ref = _ref.__2(ref paramRef); // и вернёт значение и передаст по ссылке
            //_ref.__3();
            #endregion

            Console.WriteLine("Hello World!");
        }
    }
}
