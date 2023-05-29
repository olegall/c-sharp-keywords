using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class TryCatchFinallyThrow
    {
        private string name;

        public string Name
        {
            get => name;
            set => name = value ??
                throw new ArgumentNullException(paramName: nameof(value), message: "Name cannot be null");
        }

        char _1(string args) => args.Length >= 1 ? args[0] : throw new ArgumentException("Please supply at least one argument.");

        DateTime ToDateTime(IFormatProvider provider) => throw new InvalidCastException("Conversion to a DateTime is not supported.");

        void _2() 
        {
            try
            {
                var result = Process(-3, 4);
                Console.WriteLine($"Processing succeeded: {result}");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine($"Processing failed: {e.Message}");
            }

            try
            {
                var result = Process(-3, 4);
                Console.WriteLine($"Processing succeeded: {result}");
            }
            catch (Exception e)
            {
                //LogError(e, "Processing failed.");
                throw;
            }

            try
            {
                var result = Process(-3, 4);
                Console.WriteLine($"Processing succeeded: {result}");
            }
            catch (Exception e) when (e is ArgumentException || e is DivideByZeroException)
            {
                Console.WriteLine($"Processing failed: {e.Message}");
            }

            try
            {
                //var result = await ProcessAsync(-3, 4, cancellationToken);
                var result = Process(-3, 4);
                Console.WriteLine($"Processing succeeded: {result}");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine($"Processing failed: {e.Message}");
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("Processing is cancelled.");
            }
        }

        public static async Task Run()
        {
            try
            {
                Task<int> processing = ProcessAsync(-1);
                Console.WriteLine("Launched processing.");

                int result = await processing;
                Console.WriteLine($"Result: {result}.");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine($"Processing failed: {e.Message}");
            }
            // Output:
            // Launched processing.
            // Processing failed: Input must be non-negative. (Parameter 'input')
        }

        private static async Task<int> ProcessAsync(int input)
        {
            if (input < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(input), "Input must be non-negative.");
            }

            await Task.Delay(500);
            return input;
        }

        async Task ProcessAsync(int input, CancellationToken ct) 
        { 
        }

        bool Busy;

        public async Task HandleRequest(int itemId, CancellationToken ct)
        {
            Busy = true;

            try
            {
                await ProcessAsync(itemId, ct);
            }
            finally
            {
                Busy = false;
            }
        }

        public async Task ProcessRequest(int itemId, CancellationToken ct)
        {
            Busy = true;

            try
            {
                await ProcessAsync(itemId, ct);
            }
            //catch (Exception e) when (e is not OperationCanceledException)
            //{
            //    //LogError(e, $"Failed to process request for item ID {itemId}.");
            //    throw;
            //}
            finally
            {
                Busy = false;
            }
        }

        int Process(int a1, int a2)
        {
            return 0;
        }

        public void Run1()
        {
        }
    }
}
