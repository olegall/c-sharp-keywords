using System;

namespace ConsoleApp1
{
    class Static
    {
        static class CompanyEmployee
        {
            public static void DoSomething() { /*...*/ }
            public static void DoSomethingElse() { /*...*/  }
        }

        public class MyBaseC
        {
            public struct MyStruct
            //public static struct MyStruct // static нельзя
            {
                public static int x = 100;
            }
        }

        #region 
        public class Employee4
        {
            public string id;
            public string name;

            public Employee4()
            {
            }

            public Employee4(string name, string id)
            {
                this.name = name;
                this.id = id;
            }

            public static int employeeCounter;

            public static int AddEmployee()
            {
                return ++employeeCounter;
            }
        }

        class MainClass : Employee4
        {
            public static void Main_()
            {
                Console.Write("Enter the employee's name: ");
                string name = Console.ReadLine();
                Console.Write("Enter the employee's ID: ");
                string id = Console.ReadLine();

                // Create and configure the employee object.
                Employee4 e = new Employee4(name, id);
                Console.Write("Enter the current number of employees: ");
                string n = Console.ReadLine();
                
                Employee4.employeeCounter = Int32.Parse(n);
                Employee4.AddEmployee();

                // Display the new information.
                Console.WriteLine($"Name: {e.name}");
                Console.WriteLine($"ID:   {e.id}");
                Console.WriteLine($"New Number of Employees: {Employee4.employeeCounter}");
            }
        }
        /*
        Input:
        Matthias Berndt
        AF643G
        15
         *
        Sample Output:
        Enter the employee's name: Matthias Berndt
        Enter the employee's ID: AF643G
        Enter the current number of employees: 15
        Name: Matthias Berndt
        ID:   AF643G
        New Number of Employees: 16
        */
        #endregion

        public void Run()
        {
            MainClass.Main_();
        }
    }
}