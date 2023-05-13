namespace ConsoleApp1
{
    public class Ref
    {
        private int a1 = 0;  // вызовется _1(out int param). const нельзя
        private int? a2 = 1; // вызовется _1(out int? param). const нельзя

        public void _1(ref int param)
        {
            param = 100; // не обязательно. такое значение приобретёт внешняя объявленная переменная
        }
        
        public void _1(ref int? param) // int? - работает перегрузка
        {            
            param = null; // такое значение приобретёт внешняя объявленная переменная
        }

        public int _2(ref int param)
        {
            param = 10; // не обязательно
            return 11;
        }

        //public void __3()
        //{
        //    string arg = "10";
        //    // long result = number; // недоступно
        //    var a1 = Int64.TryParse(arg, ref var number);
        //    long result = number;
        //}

        public void Run() 
        {
            // 35, 36 строки вызываются подряд, после вызов 2-х методов подряд!
            _1(ref a1); // обязательно out, обязательно int param - назван так же
            _1(ref a2); // обязательно out, обязательно int param - назван так же
            var a1Ref = _2(ref a1); // и вернёт значение и передаст по ссылке
                                                //_ref.__3();
        }
    }
}
