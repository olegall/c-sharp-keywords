using System;
namespace ConsoleApp1
{
    // private нельзя
    /*private class PrivateClass
    { 
    }*/

    public class Out
    {
        // что ближе - out/ref, in/out ... ?
        // какая разница - просто ссылочный тип, ref или out? во всех случаях влияние оказывается на внешний объект

        private int a1;  // вызовется _1(out int param). не обязательно присваивать
        private int? a2 = 1; // вызовется _1(out int? param). не обязательно присваивать
        private const int a3 = 0;  // можно const. надо присваивать
        //private const int? a4 = 0;  // нельзя const. надо присваивать

        public void _1(out int param)
        {
            param = 100; // такое значение приобретёт внешняя объявленная переменная
        }
        
        // int? - работает перегрузка
        public void _1(out int? param)
        {
            param = null; // такое значение приобретёт внешняя объявленная переменная
        }

        public void _2()
        {
            string arg = "10";
            // long result = number; // передать вовне внутри метода нельзя. только через параметр
            var a1 = Int64.TryParse(arg, out var number);
            long result = number;
        }

        public void Run() 
        {
            _1(out a1); // обязательно out, обязательно int param - назван так же
            _1(out a2); // обязательно out, обязательно int param - назван так же
            _2();
        }
    }
}
