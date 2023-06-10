using System;

namespace ConsoleApp1
{
    class Interface
    {
        interface ISampleInterface
        {
            void SampleMethod();
        }

        class ImplementationClass : ISampleInterface
        {
            // Explicit interface member implementation:
            void ISampleInterface.SampleMethod()
            {
                // Method implementation.
            }

            static void Main()
            {
                // Declare an interface instance.
                ISampleInterface obj = new ImplementationClass();
                ImplementationClass obj2 = new ImplementationClass();

                // Call the member.
                obj.SampleMethod();
            }

            public void Run() 
            {
                Main();
            }
        }



        interface IPoint
        {
            // Property signatures:
            int X { get; set; }

            int Y { get; set; }

            double Distance { get; }
        }

        class Point : IPoint
        {
            // Constructor:
            public Point(int x, int y)
            {
                X = x;
                Y = y;
            }

            // Property implementation:
            public int X { get; set; }

            public int Y { get; set; }

            // Property implementation
            public double Distance => Math.Sqrt(X * X + Y * Y);
        }

        class MainClass
        {
            static void PrintPoint(IPoint p)
            {
                Console.WriteLine("x={0}, y={1}", p.X, p.Y);
            }

            static void Main()
            {
                IPoint p = new Point(2, 3);
                Console.Write("My Point: ");
                PrintPoint(p);
            }
        }

        public void Run()
        {
            new ImplementationClass().Run();
        }
    }
}
