namespace CovarianceAndContravariance
{
    public class Person
    {
        public Person(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }

    public class Student : Person
    {
        public Student(string name) : base(name)
        {
        }

        // Student specific fields...
    }

    public class Teacher : Person
    {
        public Teacher(string name) : base(name)
        {
        }

        // Teacher specific fields...
    }
}