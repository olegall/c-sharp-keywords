namespace ConsoleApp1
{
    class Abstract
    {
        #region
        abstract class Shape
        {
            public abstract int GetArea(); // обязательно public
        }

        

        class Square : Shape
        {
            private int _side;

            public Square(int n) => _side = n;

            // GetArea method is required to avoid a compile-time error.
            public override int GetArea() => _side * _side;

            public static void Main_()
            {
                var sq = new Square(12);
                var a1 = $"Area of the square = {sq.GetArea()}"; // Output: Area of the square = 144
            }
        }
        #endregion

        #region
        interface I
        {
            void M();
        }

        abstract class C : I
        {
            public abstract void M();
        }
        #endregion

        #region
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

            static void Main_()
            {
                
            }
        }
        #endregion

        #region
        class FooAbstract
        {
            int GetArea2() => 0;

            //public abstract int GetArea3 { get { return 0; } }
            //abstract int GetArea3 { get { return 0; } }

            //string Name { set => ""; }
            
            string a;
            //public abstract string Name { set => a = value; }

            private int a1;

            // abstract delegate int GetArea4(); // abstract нельзя
            delegate int GetArea4();
        }
        #endregion

        class Foo
        {
            //public abstract int Baz(); // обязательно public
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
