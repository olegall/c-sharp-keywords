namespace ConsoleApp1
{
    class Abstract
    {
        abstract class Shape // необязательно public
        {
            public abstract int GetArea(); // обязательно public, abstract
            //abstract int GetArea();
            public void GetArea2() { }
        }

        class Square : Shape
        {
            private int _side;

            public Square(int n) => _side = n;

            // GetArea method is required to avoid a compile-time error.
            public override int GetArea() => _side * _side; // обязательно переопределять
            //public new int GetArea() => _side * _side; // надо override
            //public int GetArea() => _side * _side; // надо override

            //void GetArea2() { }
            //new void GetArea2() { }
            //override void GetArea2() { }

            public static void Main_()
            {
                var sq = new Square(12);
                var a1 = $"Area of the square = {sq.GetArea()}"; // Output: Area of the square = 144
            }
        }

        interface I
        {
            void Foo();
        }

        abstract class C : I
        {
            public abstract void Foo();
        }

        // Abstract class
        abstract class BaseClass
        {
            protected int _x = 100;
            protected int _y = 150;

            // Abstract method
            public abstract void AbstractMethod();

            // Abstract properties
            public abstract int X { get; }
            public abstract int Y { get; }
        }

        class DerivedClass : BaseClass
        {
            public override void AbstractMethod()
            {
                _x++;
                _y++;
            }

            public override int X   // overriding property
            {
                get
                {
                    return _x + 10;
                }
            }

            public override int Y   // overriding property
            {
                get
                {
                    return _y + 10;
                }
            }
        }

        class FooAbstract
        {
            int GetArea2() => 0;

            //public abstract int GetArea3 { get { return 0; } }

           
            //string a;
            //public abstract string Name { set => a = value; }

            //public abstract delegate int GetArea3(); // abstract нельзя
            delegate int GetArea4();
        }

        public void Run()
        {
            Square.Main_();

            var o = new DerivedClass();
            o.AbstractMethod();
            var a1 = $"x = {o.X}, y = {o.Y}"; // Output: x = 111, y = 161
            // BaseClass bc = new BaseClass();   // Error 
        }
    }
}
