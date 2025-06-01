using System;

namespace ConsoleApp1
{
    class Delegate_
    {
        public delegate void MessageDelegate(string message);
        //public Delegate void MessageDelegate(string message);
        //public delegate int AnotherDelegate(MyType m, long num);

        private delegate void Foo1(int a1); // Foo1 - метод? тип? экземпляр типа делегат?
        //public delegate void Foo1(); // перегрузить по сигнатуре нельзя
        delegate int Foo2();
        delegate int Foo3(int a1);

        public void _1()
        {
            Action<string> stringAction = str => { };
            Action<object> objectAction = (obj) => { };
            //var objectAction2 = (obj) => { };


            // Valid due to implicit reference conversion of objectAction to Action<string>, but may fail at run time.
            //Action<string> combination = stringAction + objectAction; // runtime System.ArgumentException: "Delegates must be of the same type."
        }

        public void _2() 
        {
            Action<string> stringAction = str => { };
            Action<object> objectAction = obj => { };

            // Creates a new delegate instance with a runtime type of Action<string>.
            Action<string> wrappedObjectAction = new Action<string>(objectAction);

            // The two Action<string> delegate instances can now be combined.
            Action<string> combination = stringAction + wrappedObjectAction; // watch {Method = <Произошла внутренняя ошибка при вычислении выражения>}
        }

        public void Run() 
        {
            _1();
            _2();
        }
    }
}
