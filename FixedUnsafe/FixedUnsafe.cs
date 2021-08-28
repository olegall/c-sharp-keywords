using System;

namespace FixedUnsafe
{
    struct Point
    {
        public int x;
        public int y;
    }

    public class FixedUnsafe_ // если назвать класс как пространство имён, нельзя его вызвать
    {
        Point point = new Point();
        double[] arr = { 0, 1.5, 2.3, 3.4, 4.0, 5.9 };
        string str = "Hello World";

        // The following two assignments are equivalent. Each assigns the address
        // of the first element in array arr to pointer p.

        unsafe private static void ModifyFixedStorage()
        {
            // Variable pt is a managed variable, subject to garbage collection.
            Point pt = new Point();

            // Using fixed allows the address of pt members to be taken,
            // and "pins" pt so that it is not relocated.

            //fixed (int* p = &pt.x)
            //{
            //    *p = 1;
            //}
        }

        unsafe private void Ex()
        {
            // You can initialize a pointer by using an array.
            // p - обязательно структура
            // fixed обязательно в unsafe
            fixed (double* p = arr) { /*...*/ }

            // You can initialize a pointer by using the address of a variable.
            fixed (double* p = &arr[0]) { /*...*/ }

            // The following assignment initializes p by using a string.
            fixed (char* p = str) { /*...*/ }

            // The following assignment is not valid, because str[0] is a char,
            // which is a value, not a variable.
            //fixed (char* p = &str[0]) { /*...*/ }            

            byte[] srcarray; // что плохого будет, если не проинициализировать?
            byte[] dstarray;
            // Multiple pointers can be initialized in one statement if they are all the same type:
            fixed (byte* ps = srcarray, pd = dstarray)
            {
            }

            fixed (int* p1 = &point.x)
            {
                fixed (double* p2 = &arr[5])
                {
                    // Do something with p1 and p2.
                }
            }

            fixed (byte* ps = srcarray, pd = dstarray)
            {
                byte* pSourceCopy = ps;
                pSourceCopy++; // point to the next element.
                //ps++; // invalid: cannot modify ps, as it is declared in the fixed statement.
            }
        }
        
        unsafe public static void FixedSpanExample()
        {
            int[] PascalsTriangle = {
                          1,
                        1,  1,
                      1,  2,  1,
                    1,  3,  3,  1,
                  1,  4,  6,  4,  1,
                1,  5,  10, 10, 5,  1
            };

            Span<int> RowFive = new Span<int>(PascalsTriangle, 10, 5);

            fixed (int* ptrToRow = RowFive)
            {
                // Sum the numbers 1,4,6,4,1
                var sum = 0;
                for (int i = 0; i < RowFive.Length; i++)
                {
                    sum += *(ptrToRow + i);
                }
                Console.WriteLine(sum);
            }
        }
    }
}
