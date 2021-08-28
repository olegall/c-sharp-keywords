using System;

namespace Enum
{
    public class EnumConversionExample
    {
        public static void Main()
        {
            // посмотреть все значения енама

            Season a = Season.Autumn;
            Console.WriteLine($"Integral value of {a} is {(int)a}");  // output: Integral value of Autumn is 2

            Season a1 = (Season)1; // output: Summer

            var a2 = (Season)10; // output: 10. в Season такого поля нет, исключения нет. var - Season

            var a3 = (int)(Season)10; // output: 10. в Season такого поля нет, исключения нет. var - int
            
            var a4 = (short)(long)(int)(Season)10; // output: 10. в Season такого поля нет, исключения нет. var - int

            //var a5 = (SeasonUint)(-10); // если  : uint - ошибка
            
            var a6 = unchecked((SeasonUint)(-10)); // если убрать unchecked - ошибка
            
            var a7 = (byte)(SeasonInt)10; // если  : uint - ошибка
             
            // precision loss - потеря точности
            // explicit cast   inplicit cast
            var a8 = (byte)(int)255; // если 256 - ошибка. почему нет предупреждения потери точности?

            byte b = 1;
            var a9 = (int)b;
        }
    }
}
