using System;

namespace ConsoleApp1
{
    struct OptionStruct { }

    public class Ref
    {
        private int? a1 = 1; // по документации надо присваивать, но работает без присвоения

        public void Foo1(ref int? param) // int? - работает перегрузка
        {
            //param = 2;
            param = null; // можно не присваивать. такое значение приобретёт внешняя объявленная переменная
        }

        //public static void ForceByRef(ref readonly OptionStruct thing)
        //{
        //    // elided
        //}

        //public void __3()
        //{
        //    string arg = "10";
        //    // long result = number; // недоступно
        //    var a1 = Int64.TryParse(arg, ref var number);
        //    long result = number;
        //}

        public void Main_() 
        {
            Console.WriteLine("*** REF ***");
            Foo1(ref a1); // обязательно out, обязательно int param - назван так же
            // можно удалить отсюда и из сигнатуры

            //_ref.__3();

            string s = "hello";
            M(s);
            Console.WriteLine(s);
            M(ref s);
            Console.WriteLine(s);
        }

        public void M(string s)
        {
            s = "this won't change the original string";
        }

        public void M(ref string s)
        {
            s = "this will change the original string";
        }
    }
}
