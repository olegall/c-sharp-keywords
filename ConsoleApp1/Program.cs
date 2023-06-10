using FixedUnsafe;
using System;
using Volatile;
using Yield;

namespace ConsoleApp1
{
    class Program
    {
        /*
            IAsyncEnumerable<string> elements = MyAsyncIteratorMethod();
            await foreach (string element in elements)
            {
               // ...
            }
        */

        static void Main(string[] args)
        {
            // каждый класс сделать IRunnable. В цикле запустить все объекты IRunnable
            new Abstract().Run();
            new CheckedUnchecked().Run();
            new Delegate().Run();
            new Base().Run();
            new Default().Run();
            new Dynamic().Run1();
            new Dynamic().Run2();
            new Enum().Run();
            new Event().Run();
            new Extern().Run();
            new Operator().Run();
            new Out().Run();
            new Readonly().Run();
            new Ref().Run();
            new Static().Run();
            new This().Run();
            new ImplicitExplicitOperator().Run();
            new In().Run();
            new Is().Run();
            new IsAsTypeofCast().Run();
            new Lock_().Run();
            new TryCatchFinallyThrow().Run_();
            new Using().Run();
            new VirtualOverride().Run1();
            new VirtualOverride().Run2();

            #region Yield
            PowersOf2.Main();
            GalaxyClass.ShowGalaxies();
            #endregion

            #region Volatile
            WorkerThreadExample.Main();
            #endregion

            #region External
            //ExternTest.Main();
            #endregion

            #region Fixed Unsafe
            FixedUnsafe_.FixedSpanExample();
            UnsafeCode_PointerTypes_FunctionPointers.Ex2();
            UnsafeCode_PointerTypes_FunctionPointers.Ex3();
            UnsafeCode_PointerTypes_FunctionPointers.AccessEmbeddedArray();
            UnsafeCode_PointerTypes_FunctionPointers.UnsafeCopyArrays();
            #endregion

            Console.WriteLine("***************");
            Console.ReadLine();
        }
    }
}