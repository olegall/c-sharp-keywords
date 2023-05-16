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

        // формат {static implicit/explicit operator тип(тип объект)}
        public static implicit operator byte(Digit d) => d.digit; // когда imlicit не нужен Cast
        public static explicit operator Digit(byte b) => new Digit(b); // когда explicit нужен Cast

        public override string ToString() => $"{digit}";
    }

    // сравнение с обычным кастом?
    class ImplicitExplicitOperator
    {
        public void Run()
        {
            var d = new Digit(7);
            byte number = d; // output: 7. implicit convertion
            Digit digit = (Digit)number; // output: 7. explicit conversion
        }
    }
}