using System;

namespace FixedUnsafe
{
    internal unsafe struct Buffer
    {
        public fixed char fixedBuffer[128];
    }

    internal unsafe class Example
    {
        public Buffer buffer = default;
    }

    public class UnsafeCode_PointerTypes_FunctionPointers
    {
        unsafe void Ex1() // unsafe с методом
        {
            // указатель д.б. в unsafe
            //type* identifier;
            void* identifier; //allowed but not recommended

            int* p1, p2, p3;   // Ok
            //int* p1, *p2, *p3;   // Invalid in C#

            int* p4;    //: p is a pointer to an integer.
            int** p5;   //: p is a pointer to a pointer to an integer.
            int*[] p6;  //: p is a single - dimensional array of pointers to integers.
            char* p7;   //: p is a pointer to a char.
            void* p8;   //: p is a pointer to an unknown type.
        }

        public static void Ex2()
        {
            // Normal pointer to an object.
            int[] a = new int[5] { 10, 20, 30, 40, 50 };
            // Must be in unsafe code to use interior pointers.
            unsafe // просто unsafe
            {
                // Must pin object on heap so that it doesn't move while using interior pointers.
                fixed (int* p = &a[0])
                {
                    // p is pinned as well as object, so create another pointer to show incrementing it.
                    int* p2 = p;
                    Console.WriteLine(*p2);
                    // Incrementing p2 bumps the pointer by four bytes due to its type ...
                    p2 += 1;
                    Console.WriteLine(*p2);
                    p2 += 1;
                    Console.WriteLine(*p2);
                    Console.WriteLine("--------");
                    Console.WriteLine(*p);
                    // Dereferencing p and incrementing changes the value of a[0] ...
                    *p += 1;
                    Console.WriteLine(*p);
                    *p += 1;
                    Console.WriteLine(*p);
                }
            }

            Console.WriteLine("--------");
            Console.WriteLine(a[0]);

            /*
                Output:
                10
                20
                30
                --------
                10
                11
                12
                --------
                12
             */
        }

        public static void Ex3() 
        {
            int number = 1024;

            unsafe
            {
                // Convert to byte:
                byte* p = (byte*)&number;

                Console.Write("The 4 bytes of the integer:");

                // Display the 4 bytes of the int variable:
                for (int i = 0; i < sizeof(int); ++i)
                {
                    Console.Write(" {0:X2}", *p);
                    // Increment the pointer:
                    p++;
                }
                Console.WriteLine();
                Console.WriteLine("The value of the integer: {0}", number);

                /* Output:
                    The 4 bytes of the integer: 00 04 00 00
                    The value of the integer: 1024
                */
            }
        }

        public static void AccessEmbeddedArray()
        {
            var example = new Example();

            unsafe
            {
                // Pin the buffer to a fixed location in memory.
                fixed (char* charPtr = example.buffer.fixedBuffer)
                {
                    *charPtr = 'A';
                }
                // Access safely through the index:
                char c = example.buffer.fixedBuffer[0];
                Console.WriteLine(c);

                // Modify through the index:
                example.buffer.fixedBuffer[0] = 'B';
                Console.WriteLine(example.buffer.fixedBuffer[0]);
            }
        }

        static unsafe void Copy(byte[] source, int sourceOffset, byte[] target, int targetOffset, int count)
        {
            // If either array is not instantiated, you cannot complete the copy.
            if ((source == null) || (target == null))
            {
                throw new System.ArgumentException();
            }

            // If either offset, or the number of bytes to copy, is negative, you
            // cannot complete the copy.
            if ((sourceOffset < 0) || (targetOffset < 0) || (count < 0))
            {
                throw new System.ArgumentException();
            }

            // If the number of bytes from the offset to the end of the array is
            // less than the number of bytes you want to copy, you cannot complete
            // the copy.
            if ((source.Length - sourceOffset < count) || (target.Length - targetOffset < count))
            {
                throw new System.ArgumentException();
            }

            // The following fixed statement pins the location of the source and
            // target objects in memory so that they will not be moved by garbage
            // collection.
            fixed (byte* pSource = source, pTarget = target)
            {
                // Copy the specified number of bytes from source to target.
                for (int i = 0; i < count; i++)
                {
                    pTarget[targetOffset + i] = pSource[sourceOffset + i];
                }
            }
        }

        public static void UnsafeCopyArrays()
        {
            // Create two arrays of the same length.
            int length = 100;
            byte[] byteArray1 = new byte[length];
            byte[] byteArray2 = new byte[length];

            // Fill byteArray1 with 0 - 99.
            for (int i = 0; i < length; ++i)
            {
                byteArray1[i] = (byte)i;
            }

            // Display the first 10 elements in byteArray1.
            Console.WriteLine("The first 10 elements of the original are:");
            for (int i = 0; i < 10; ++i)
            {
                Console.Write(byteArray1[i] + " ");
            }
            Console.WriteLine("\n");

            // Copy the contents of byteArray1 to byteArray2.
            Copy(byteArray1, 0, byteArray2, 0, length);

            // Display the first 10 elements in the copy, byteArray2.
            Console.WriteLine("The first 10 elements of the copy are:");
            for (int i = 0; i < 10; ++i)
            {
                Console.Write(byteArray2[i] + " ");
            }
            Console.WriteLine("\n");

            // Copy the contents of the last 10 elements of byteArray1 to the
            // beginning of byteArray2.
            // The offset specifies where the copying begins in the source array.
            int offset = length - 10;
            Copy(byteArray1, offset, byteArray2, 0, length - offset);

            // Display the first 10 elements in the copy, byteArray2.
            Console.WriteLine("The first 10 elements of the copy are:");
            for (int i = 0; i < 10; ++i)
            {
                Console.Write(byteArray2[i] + " ");
            }
            Console.WriteLine("\n");
            /* Output:
                The first 10 elements of the original are:
                0 1 2 3 4 5 6 7 8 9

                The first 10 elements of the copy are:
                0 1 2 3 4 5 6 7 8 9

                The first 10 elements of the copy are:
                90 91 92 93 94 95 96 97 98 99
            */
        }
    }
}