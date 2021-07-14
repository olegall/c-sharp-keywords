namespace ConsoleApp1
{
    class CS0663_Example
    {
        // Compiler error CS0663: "Cannot define overloaded
        // methods that differ only on in, ref and out".
        public void SampleMethod(in int i) { }
        //public void SampleMethod(ref int i) { }
    }

    class InOverloads
    {
        public void SampleMethod(in int i) { }
        public void SampleMethod(int i) { }
    }

    class In
    {
        // The in keyword causes arguments to be passed by reference but ensures the argument is not modified

        public void __1__(in int param) 
        {
            var a = param; // что-то делаем с param, но гарантия, что не изменяется. var - ссылочный тип? раз передаётся по ссылке
            //param = 100; // присваивать нельзя, в out надо
        }

        public void __2__(in int? param)
        {

        }

        public int __3__(in int param)
        {
            return param; // можно вернуть
            //return 11; // можно вернуть
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
    }
}
