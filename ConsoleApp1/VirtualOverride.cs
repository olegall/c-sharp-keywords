namespace ConsoleApp1
{
    public partial class VirtualOverride
    {
        class A
        {
            // virtual auto-implemented property. Overrides can only
            // provide specialized behavior if they implement get and set accessors.
            public virtual string Name { get; set; }

            // ordinary virtual property with backing field
            private int num;
            public virtual int Number
            {
                get { return num; }
                set { num = value; }
            }
        }

        class B : A
        {
            private string name;

            // Override auto-implemented property with ordinary property
            // to provide specialized accessor behavior.
            public override string Name
            {
                get
                {
                    return name;
                }
                set
                {
                    if (!string.IsNullOrEmpty(value))
                    {
                        name = value;
                    }
                    else
                    {
                        name = "Unknown";
                    }
                }
            }
        }
        


        class A2
        {
            public virtual string Name { get; set; } = "virtual";
        }

        class B2 : A2
        {
            public override string Name { get; set; } = "override";
            
            public string VirtualName { get { return base.Name; } }

            public string OverrideName => this.Name;
        }
        


        class A3
        {
            public virtual string Name { get; set; }
        }

        class B3 : A3
        {
            public override string Name { get; set; }
            
            public string VirtualName { get { return base.Name; } }

            public string OverrideName => this.Name;
        }



        class A4
        {
            public virtual string Name { get; set; }
            
            public virtual void Foo(){}
            
            public virtual void Foo2(){}
            
            public virtual void Foo3(){}

            // Declare the delegate (if using non-generic pattern).
            //public delegate void SampleEventHandler(object sender, SampleEventArgs e);

            // Declare the event.
            //public virtual event SampleEventHandler SampleEvent;
        }

        class B4 : A4
        {
            public override string Name { get; set; }
            
            public override void Foo(){}
            
            public void Foo2(){}

            // можно без override Foo3

            //public override void Foo4() { } // д.б. virtual
        }

        class C4 : B4
        {
            public override void Foo(){}
            
            public void Foo2(){}
        }

        public void Run1()
        {
            var A2 = new A2();
            var B2 = new B2();
            var result2 = $"{B2.VirtualName} {B2.OverrideName}";
            
            var A3 = new A3();
            var B3 = new B3();
            A3.Name = "virtual";
            B3.Name = "override";
            var result3 = $"{A3.Name} {B3.Name}    {B3.VirtualName} {B3.OverrideName}";
        }
    }
}