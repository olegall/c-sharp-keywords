using System;

namespace ConsoleApp1
{
    public class Enum
    {
        [Flags]
        public enum Days
        {
            None = 0b_0000_0000,  // 0
            Monday = 0b_0000_0001,  // 1
            Tuesday = 0b_0000_0010,  // 2
            Wednesday = 0b_0000_0100,  // 4
            Thursday = 0b_0000_1000,  // 8
            Friday = 0b_0001_0000,  // 16
            Saturday = 0b_0010_0000,  // 32
            Sunday = 0b_0100_0000,  // 64
            Weekend = Saturday | Sunday // можно использовать что определено
        }

        // можно внутри и вне класса. конфликта нет
        enum Season // по умолчанию видимо int
        {
            Spring,
            Summer,
            Autumn,
            Winter
        }
        public class Wrapper
        {
            enum Season
            {
                Spring,
                Summer,
                Autumn,
                Winter
            }
        }

        enum SeasonUint : uint
        {
            Spring,
            Summer,
            Autumn,
            Winter
        }

        enum SeasonInt : int
        {
            Spring,
            Summer,
            Autumn,
            Winter
        }

        public void Run()
        {
            Days meetingDays = Days.Monday | Days.Wednesday | Days.Friday; // Monday, Wednesday, Friday

            Days workingFromHomeDays = Days.Thursday | Days.Friday; 
            var a1 = $"Join a meeting by phone on {meetingDays & workingFromHomeDays}"; // Join a meeting by phone on Friday

            //bool isMeetingOnTuesday = (meetingDays & Days.Tuesday) == Days.Tuesday; // false

            var a2 = (Days)37; // Monday, Wednesday, Saturday

            Season a3 = Season.Autumn; // Autumn

            var a4 = (Season)1; // output: Summer

            var a5 = (Season)4; // output: 4 в Season такого поля нет, исключения нет. var - Season

            var a7 = (int)(Season)10; // output: 10. в var - int

            //var a5 = (SeasonUint)(-10); // если  : uint - ошибка

            //var a9 = unchecked((SeasonUint)(-10)); // если убрать unchecked - ошибка

            //var a10 = (byte)(SeasonInt)10; // если  : uint - ошибка

            // precision loss - потеря точности
            // explicit cast   inplicit cast
            //var a11 = (byte)(int)255; // если 256 - ошибка. почему нет предупреждения потери точности?

            //byte b = 1;
            //var a12 = (int)b;
        }
    }
}