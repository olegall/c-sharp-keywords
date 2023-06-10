using System;
using System.Runtime.InteropServices;

namespace ConsoleApp1
{
    public class Extern
    {
        [DllImport("User32.dll", CharSet = CharSet.Unicode)]
        public static extern int MessageBox(IntPtr h, string m, string c, int type);

        public static int Main_()
        {
            string myString;
            Console.Write("Enter your message: ");
            myString = Console.ReadLine();
            return MessageBox((IntPtr)0, myString, "My Message Box", 0);
        }

        public void Run()
        {
            Main_();
        }
    }
}
