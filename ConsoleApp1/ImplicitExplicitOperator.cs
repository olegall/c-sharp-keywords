using System;

namespace ConsoleApp1
{
    public readonly struct Digit
    {
        private readonly byte digit;

        public Digit(byte digit)
        {
            if (digit > 9)
            {
                throw new ArgumentOutOfRangeException(nameof(digit), "Digit cannot be greater than nine.");
            }
            this.digit = digit;
        }
        // формат static и implicit/explicit и operator и тип
                                        // тип, а потом скобки
        public static implicit operator byte(Digit d) => d.digit;
        public static explicit operator Digit(byte b) => new Digit(b);

        public override string ToString() => $"{digit}";
    }

    // сравнение с обычным кастом?
    class ImplicitExplicitOperator
    {
    }
}