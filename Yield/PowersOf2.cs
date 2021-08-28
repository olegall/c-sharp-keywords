using System;
using System.Collections.Generic;
namespace Yield
{
    public class PowersOf2
    {
        public static void Main()
        {
            // Display powers of 2 up to the exponent of 8:
            foreach (int i in Power(2, 8))
            {
                Console.Write("{0} ", i);
            }
            Console.Write("\n");
            foreach (int i in PowerNotYield(2, 8))
            {
                Console.Write("{0} ", i);
            }
            Console.Write("\n");
        }

        public static IEnumerable<int> Power(int number, int exponent)
        {
            int result = 1;
            for (int i = 0; i < exponent; i++)
            {
                result = result * number;
                yield return result; // ф-я возвращает IEnumerable, а result = int
                //return result; // ошибка

                // Всегда yield с return или break
                //yield return <expression>;
                //yield break;

                // могут идти друг за другом
                // ошибки нет
                //yield return <expression>;
                //yield break;
                // предупреждение
                //yield break;
                //yield return <expression>;
            }
        }

        // Output: 2 4 8 16 32 64 128 256

        public static IEnumerable<int> PowerNotYield(int number, int exponent)
        {
            int result = 1;
            IList<int> results = new List<int>();
            for (int i = 0; i < exponent; i++)
            {
                result = result * number;
                results.Add(result);
            }
            return results;
        }
    }
}
