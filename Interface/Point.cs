﻿using System;

namespace Interface
{
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
        public double Distance =>
           Math.Sqrt(X * X + Y * Y);

    }
}
