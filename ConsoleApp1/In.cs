namespace ConsoleApp1
{
    class CS0663_Example
    {
        // Compiler error CS0663: "Cannot define overloaded
        // methods that differ only on in, ref and out".
        public void SampleMethod(in int i) { }
        //public void SampleMethod(ref int i) { }
    }

    class In
    {


        // The in keyword causes arguments to be passed by reference but ensures the argument is not modified
        
        public void SampleMethod(in int i) { }
        public void SampleMethod(int i) { }

        public void _1(in int param)
        {
            var a = param; // что-то делаем с param, но гарантия, что не изменяется. var - ссылочный тип? раз передаётся по ссылке
            //param = 100; // присваивать нельзя, т.к. только для чтения. в out надо
        }

        public void _2(in int? param)
        {

        }

        public void Method(in int argument)
        {
            // implementation removed
        }

        // если закомментировать, будет вызываться без проблем Method(in int argument)
        // если раскомментировать, будет вызываться перегруженная версия, если в вызываемом методе аргумент с in
        public void Method(int argument)
        {
            // implementation removed
        }

        void InArgExample(in int number)
        {
            // Uncomment the following line to see error CS8331
            //number = 19;
        }

        private int a1 = 10;  // The argument must be initialized before calling the method (ошибки нет). const нельзя
        private int? a2 = 1; // вызовется public void __2(out int? param). const нельзя

        public void Run() 
        {
            int readonlyArgument = 44;
            InArgExample(readonlyArgument);
            //Console.WriteLine(readonlyArgument);     // value is still 44

            _1(in a1); // обязательно out, обязательно int param - назван так же
            _1(a1); // какая разница - вызывать с in или без?

            _2(in a2); // обязательно out, обязательно int param - назван так же
            


            Method(5); // OK, temporary variable created.
            //Method(5L); // CS1503: no implicit conversion from long to int
            Method((int)5L);
            short s = 0;
            Method(s); // OK, temporary int created with the value 0
            //Method(in s); // CS1503: cannot convert from in short to in int
            //Method(in (int)s);
            int i = 42;
            Method(i); // passed by readonly reference
            Method(in i); // passed by readonly reference, explicitly using `in`


            Method(5); // Calls overload passed by value
            //_in.Method(5L); // CS1503: no implicit conversion from long to int

            Method(s); // Calls overload passed by value.
            //_in.Method(in s); // CS1503: cannot convert from in short to in int

            Method(i); // Calls overload passed by value
            Method(in i); // passed by readonly reference, explicitly using `in
        }
    }
}
