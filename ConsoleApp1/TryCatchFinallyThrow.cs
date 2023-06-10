using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class TryCatchFinallyThrow
    {
        private string name;

        public string Name
        {
            get => name;
            set => name = value ??
                throw new ArgumentNullException(paramName: nameof(value), message: "Name cannot be null");
        }

        string _1(string args) 
        {
            string first = args.Length >= 1 ? args[0] : throw new ArgumentException("Please supply at least one argument.");
            return first;
        }

        DateTime ToDateTime(IFormatProvider provider) => throw new InvalidCastException("Conversion to a DateTime is not supported.");

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

        async Task ProcessAsync(int input, CancellationToken ct) { }

        async Task ProcessAsync(int a1, int a2, CancellationToken ct) { }

        int Process(int a1, int a2)
        {
            // a1/a2, a1 = 0
            // a1, a2 - nullable
            return 0; 
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

        public async Task Run_()
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
                CancellationToken cancellationToken = null;
                var result = await ProcessAsync(-3, 4, cancellationToken);

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

            _1("xxx");
        }
    }
}