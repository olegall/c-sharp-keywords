using System;

namespace ConsoleApp1
{
    public class SampleCollection<T>
    {
        // Declare an array to store the data elements.
        private T[] arr = new T[100];

        // Define the indexer to allow client code to use [] notation.
        public T this[int i]
        {
            get { return arr[i]; }
            set { arr[i] = value; }
        }
    }

    class SampleCollection2<T>
    {
        // Declare an array to store the data elements.
        private T[] arr = new T[100];
        int nextIndex = 0;

        // Define the indexer to allow client code to use [] notation.
        public T this[int i] => arr[i];

        public void Add(T value)
        {
            if (nextIndex >= arr.Length)
                throw new IndexOutOfRangeException($"The collection can hold only {arr.Length} elements.");

            arr[nextIndex++] = value;
        }
    }

    class SampleCollection3<T>
    {
        // Declare an array to store the data elements.
        private T[] arr = new T[100];

        // Define the indexer to allow client code to use [] notation.
        public T this[int i]
        {
            get => arr[i];
            set => arr[i] = value;
        }
    }

    class This
    {
        private event EventHandler ShapeChanged;

        private EventArgs e;

        private int[] array = {1, 2};

        //this;
        //This this;
        //This this _this;
        private This _this;

        private string login; // login или Name проинициализируется быстрее?
        public string Name { get; set; } = "Oleg";

        public int this[int param]
        {
            get { return array[param]; }
            set { array[param] = value; }
        }

        //public This()
        //{
        //    this.login = "Aleek";
        //    _2(this); 
        //}

        public void Init()
        {
            this.login = "Aleek";
            _2(this); // сработает _2(This _this), т.к. более частный
        }

        public void _1()
        {
            var a = this; 
            ShapeChanged?.Invoke(this, e);
        }

        public void _2(This _this) { } // this можно передавать как параметр

        public void _2(object _this) { } // this можно передавать как параметр

        public static void _3()
        {
            // var this_ = this; // нельзя для static
        }

        public void Run()
        {
            var thisBefore = this;
            Init(); // почему-то повлияло на thisBefore
            //new This();
            var thisAfter = this; // this - экземпляр This c проинициализированными полями. Аналог new This();

            _1();

            var a1 = this._this; // null, хотя объект This уже создан

            // индексатор
            var a2 = this[0]; // array[0] = 1
            this[0] = 0;
            var a3 = this[0]; // array[0] = 0

            // как передать this в кастомный метод?

            var stringCollection = new SampleCollection<string>();
            stringCollection[0] = "Hello, World";
            var this1 = stringCollection[0];

            var stringCollection2 = new SampleCollection2<string>();
            stringCollection2.Add("Hello, World");
            var this2 = stringCollection2[0];

            var stringCollection3 = new SampleCollection3<string>();
            stringCollection3[0] = "Hello, World.";
            var this3 = stringCollection3[0];
        }
    }
}