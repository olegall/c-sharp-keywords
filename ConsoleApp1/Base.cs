using System;

namespace ConsoleApp1
{
    class Base
    {
        public class Person
        {
            protected string ssn = "444-55-6666";
            protected string name = "John L. Malgraine";

            public virtual void GetInfo()
            {
                Console.WriteLine("Name: {0}", name);
                Console.WriteLine("SSN: {0}", ssn);
            }
        }

        class Employee : Person
        {
            public string id = "ABC567EFG";
            public override void GetInfo()
            {
                // Calling the base class GetInfo method:
                base.GetInfo();
                Console.WriteLine("Employee ID: {0}", id);
            }
        }

        public class BaseClass
        {
            int num;

            public BaseClass()
            {
                Console.WriteLine("in BaseClass()");
            }

            public BaseClass(int i)
            {
                num = i;
                Console.WriteLine("in BaseClass(int i)");
            }

            public int GetNum()
            {
                return num;
            }
        }

        public class DerivedClass : BaseClass
        {
            // This constructor will call BaseClass.BaseClass()
            public DerivedClass() : base()
            {
            }

            // This constructor will call BaseClass.BaseClass(int i)
            public DerivedClass(int i) : base(i)
            {
            }
        }

        public void Run() 
        {
            Employee E = new Employee();
            E.GetInfo();

            DerivedClass md = new DerivedClass();
            DerivedClass md1 = new DerivedClass(1);
        }
    }
}
