namespace ConsoleApp1
{
    class Dynamic
    {
        class ExampleClass
        {
            static dynamic _field;
            dynamic Prop { get; set; }

            public dynamic ExampleMethod(dynamic d)
            {
                dynamic local = "Local variable";
                int two = 2;

                if (d is int)
                {
                    return local;
                }
                else
                {
                    return two;
                }
            }
        }

        public void Run1() 
        {
            dynamic dyn = 1;
            object obj = 1;

            // Rest the mouse pointer over dyn and obj to see their
            // types at compile time.
            var a1 = dyn.GetType(); // System.Int32
            var a2 = obj.GetType(); // System.Int32

            dyn = dyn + 3;
            //obj = obj + 3; // ошибка     
        }

        public void Run2()
        {
            ExampleClass ec = new ExampleClass();
            var a1 = ec.ExampleMethod(10);
            var a2 = ec.ExampleMethod("value");

            // The following line causes a compiler error because ExampleMethod
            // takes only one argument.
            //Console.WriteLine(ec.ExampleMethod(10, 4));

            dynamic dynamic_ec = new ExampleClass();
            var a4 = dynamic_ec.ExampleMethod(10); // не подсвечивается, не переходит по F12

            // Because dynamic_ec is dynamic, the following call to ExampleMethod
            // with two arguments does not produce an error at compile time.
            // However, it does cause a run-time error.
            var a5 = dynamic_ec.ExampleMethod(10, 4);

            object a6 = dynamic_ec.ExampleMethod(10); // не подсвечивается, не переходит по F12
        }
    }
}
