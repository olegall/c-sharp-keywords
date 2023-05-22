using System;
using System.IO;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Using
    {
        class AsyncDisposableExample : IAsyncDisposable
        {
            public ValueTask DisposeAsync() 
            {
                ValueTask a1 = new ValueTask();
                return a1;
            }
        }

        public async Task Run()
        {
            await using (var resource = new AsyncDisposableExample())
            {
                // Use the resource
            }

            using (StreamReader numbersFile = File.OpenText("numbers.txt"), wordsFile = File.OpenText("words.txt"))
            {
                // Process both files
            }
        }
    }
}
