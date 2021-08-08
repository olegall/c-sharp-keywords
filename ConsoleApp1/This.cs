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
        event EventHandler ShapeChanged;
        EventArgs e;
        int a1 = 10;
        int[] array;
        private string alias;

        public int this[int param]
        {
            get { return array[param]; }
            set { array[param] = value; }
        }

        public This()
        {
            this.alias = "123";
            Foo2(this);
        }

        public void Foo()
        {
            var a = this; // this - экземпляр This c проинициализированными полями. Аналог new This();
            ShapeChanged?.Invoke(this, e);
            // как передать this в кастомный метод?
        }
        
        public void Foo2(object o)
        {
        }
    }
}