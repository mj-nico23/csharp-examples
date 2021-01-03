using System;

namespace CovarianceAndContravariance
{
    public class Contravariance
    {
        static void Main(string[] args)
        {
            var personComparer = new PersonComparer();
            var comparisonResult = Compare(personComparer);
            Console.WriteLine(comparisonResult);
        }

        public static int Compare(IMyComparer<Student> comparer)
        {
            var s1 = new Student("John");
            var s2 = new Student("Peter");

            return comparer.Compare(s1, s2);
        }
    }

    // This need to be a contravariance. 
    // We’re going to use the in keyword to anotate type T
    // input positions are limited to method input parameters and some locations in delegate parameters.
    public interface IMyComparer<in T>
    {
        int Compare(T x, T y);
    }

    public class PersonComparer : IMyComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            return string.CompareOrdinal(x.Name, y.Name);
        }
    }
}