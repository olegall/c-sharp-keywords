using Extern;
using FixedUnsafe;
using Interface;
using Lock;
using Readonly;
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
            //new Out().Run();
            //new In().Run();
            //new Ref().Run();
            //new VirtualOverride().Run1();
            //new VirtualOverride().Run2();
            //new Enum().Run();
            //new Operator().Run();
            //new This().Run();
            //new ImplicitExplicitOperator().Run();
            //new Is().Run();
            //new CheckedUnchecked().Run();
            ////new Readonly().Run();

            //#region Yield
            //PowersOf2.Main();
            //GalaxyClass.ShowGalaxies();
            //#endregion

            //#region Volatile
            //WorkerThreadExample.Main();
            //#endregion

            //#region Default
            //new Default().Main();
            //#endregion

            //#region Lock
            //AccountTest.Main();
            //#endregion

            //#region External
            ////ExternTest.Main();
            //#endregion

            //#region
            //MainClass.Main();
            //#endregion

            //#region Fixed Unsafe
            //FixedUnsafe_.FixedSpanExample();
            //UnsafeCode_PointerTypes_FunctionPointers.Ex2();
            //UnsafeCode_PointerTypes_FunctionPointers.Ex3();
            //UnsafeCode_PointerTypes_FunctionPointers.AccessEmbeddedArray();
            //UnsafeCode_PointerTypes_FunctionPointers.UnsafeCopyArrays();
            //#endregion

            //#region Readonly
            //// https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/proposals/csharp-7.2/readonly-ref
            //SamplePoint.Main();
            //#endregion

            Console.WriteLine("***************");
            Console.ReadLine();
        }
    }
}
