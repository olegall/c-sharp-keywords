namespace Readonly
{
    class Age
    {
        readonly int year;
        //readonly int year = 0; // ok
        
        int a1;
        
        Age(int year)
        {
            this.year = year;
        }

        // в методе задание значения (см. ошибку при раскомментировании year = 1967;)

        void ChangeYear(int a1) => this.a1 = a1; // конструктор как лямбда

        void ChangeYear()
        {
            //year = 1967; // Compile error if uncommented.
        }
    }
}
