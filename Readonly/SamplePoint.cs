using System;

namespace Readonly
{
    public class SamplePoint
    {
        public int x;
        // Initialize a readonly field
        public readonly int y = 25;
        public readonly int z;

        public SamplePoint()
        {
            // Initialize a readonly instance field
            z = 24;
        }

        public SamplePoint(int p1, int p2, int p3)
        {
            x = p1;
            y = p2;
            z = p3;
        }

        // Ref readonly return example
        private static readonly SamplePoint origin = new SamplePoint(0, 0, 0);
        public static ref readonly SamplePoint Origin => ref origin;

        public static void Main()
        {
            SamplePoint p1 = new SamplePoint(11, 21, 32);   // OK
            Console.WriteLine($"p1: x={p1.x}, y={p1.y}, z={p1.z}");
            SamplePoint p2 = new SamplePoint();
            p2.x = 55;   // OK
            Console.WriteLine($"p2: x={p2.x}, y={p2.y}, z={p2.z}");
            //p2.y = 66;        // Error
        }

        /*
         Output:
            p1: x=11, y=21, z=32
            p2: x=55, y=25, z=24
        */
    }
}
