using System;
namespace ConsoleApp1
{
    public class Out
    {
        public void __1(out int param)
        {
            param = 100; // обязательно
        }
        
        // int? - работает перегрузка
        public void __1(out int? param)
        {
            param = null;
        }

        public int __2(out int param)
        {
            param = 10; // обязательно
            return 11;
        }

        public void __3()
        {
            string arg = "10";
            // long result = number; // недоступно
            var a1 = Int64.TryParse(arg, out var number);
            long result = number;
        }
    }
}
