using System;

namespace ConsoleApp1
{
    public class Out
    {
        public void _1()
        {
            string arg = "10";
            var a1 = Int64.TryParse(arg, out var number);
            long result = number;
        }
    }
}
