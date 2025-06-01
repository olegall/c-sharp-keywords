using System;
namespace ConsoleApp1
{
    // private нельзя
    //private class PrivateClass
    //{
    //}

    class A 
    {
    }

    public class Out
    {
        // что ближе - out/ref, in/out ... ?
        // какая разница - просто ссылочный тип, ref или out? во всех случаях влияние оказывается на внешний объект

        private int? a1 = 1;  // вызовется _1(out int param). не обязательно присваивать

        void Foo1(out int? param)
        {
            //param = 2; // надо присвоить такое значение приобретёт внешняя объявленная переменная
            param = null;
        }

        void Foo1(out int param) // перегрузка
        {
            param = 1;
        }

        void Foo3(A a) {}

        void Foo3(out A a) { a = null; }

        void Foo4(ref A a) {}

        void Foo5(in A a) {}

        void Foo2()
        {
            // long result = number; // передать вовне внутри метода нельзя. только через параметр
            var a1 = Int64.TryParse("10", out var number);
            long result = number; // можно ниже
        }

        public void Run() 
        {
            // обязательно out, обязательно int param - назван так же
            // По перегрузке - вызовется тот, у которого тип параметра = типу внешней переменной. В данном случае nullable
            Foo1(out a1); 
            
            Foo2();
        }
    }
}
