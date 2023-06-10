using System;

namespace ConsoleApp1
{
    class Delegate
    {
        public delegate void MessageDelegate(string message);
        //public delegate int AnotherDelegate(MyType m, long num);

        public delegate void Foo1(int a1);
        //public delegate void Foo1(); // перегрузить по сигнатуре нельзя
        public delegate void Foo2();
        public delegate int Foo3();
        public delegate int Foo4(int a1);

        public void _1()
        {
            Action<string> stringAction = str => { };
            Action<object> objectAction = obj => { };

            // Valid due to implicit reference conversion of
            // objectAction to Action<string>, but may fail
            // at run time.
            Action<string> combination = stringAction + objectAction;
        }

        public void _2() 
        {
            Action<string> stringAction = str => { };
            Action<object> objectAction = obj => { };

            // Creates a new delegate instance with a runtime type of Action<string>.
            Action<string> wrappedObjectAction = new Action<string>(objectAction);

            // The two Action<string> delegate instances can now be combined.
            Action<string> combination = stringAction + wrappedObjectAction;
        }

        public void Run() 
        {
            _1();
            _2();
        }
    }
}
