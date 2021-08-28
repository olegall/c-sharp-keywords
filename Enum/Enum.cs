using System;

namespace Enum
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

    public class Enum
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
}
