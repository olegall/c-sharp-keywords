namespace ConsoleApp1
{
    public class Ref
    {
        public void __1(ref int param)
        {
            param = 100; // не обязательно
        }
        
        // int? - работает перегрузка
        public void __1(ref int? param)
        {
            param = null;
        }

        public int __2(ref int param)
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
    }
}
