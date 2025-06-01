using System;

namespace ConsoleApp1
{
    public class SampleCollection<T>
    {
        // Declare an array to store the data elements.
        private T[] arr = new T[100];

        // Define the indexer to allow client code to use [] notation.
        public T this[int i] // позволяет сделать коллекцию этого типа за счёт индексатора и массива
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

    class This // так можно назвать
    {
        private event EventHandler ShapeChanged;

        private EventArgs e;

        private int[] array = { 1, 2 };

        //this; // нельзя
        //This this; // нельзя
        //This this _this; // нельзя
        //this _this; // нельзя

        private This _this; // null. можно объявить экземпляр класса в классе
        //private This _this2 = new This(); // StackOverflowException

        private string login; // login или Name проинициализируется быстрее?
        private string Name { get; set; } = "Oleg";

        public This()
        {
            var a = this; // объект этого (текущего) класса с проинициализированными полями
            ShapeChanged?.Invoke(this, e);
        }

        int this[int param] 
        {
            get { return array[param]; }
            set { array[param] = value; }
        }

        void Init()
        {
            this.login = "Aleek";
            array[0] = 100;
            array[1] = 200;
        }

        void Foo(This _this) { } // this можно передавать как параметр

        void Foo2(object _this) { } // this можно передавать как параметр

        int a1 = 0;
        public static void _3()
        {
            // a1 = 1; // д.б. static

            int a2 = 0; // внутри можно без static
            a2 = 1;
            // var this_ = this; // нельзя для static
        }

        public void Run()
        {
            var this1 = this;
            Init();
            var this2 = this; // this - экземпляр This c проинициализированными полями. Аналог new This();
            
            new This();
            
            Foo(this); // сработает _2(This _this), т.к. более частный

            var a1 = this._this; // null, хотя объект This уже создан. This _this это не this

            // индексатор

            // как передать this в кастомный метод?

            var stringCollection = new SampleCollection<string>();
            stringCollection[0] = "Hello, World"; // массив, т.к. в классе индексатор
            var this3 = stringCollection[0]; 

            var stringCollection2 = new SampleCollection2<string>();
            stringCollection2.Add("Hello, World");
            var this4 = stringCollection2[0];

            var stringCollection3 = new SampleCollection3<string>();
            stringCollection3[0] = "Hello, World.";
            var this5 = stringCollection3[0];
        }
    }
}