using System;

namespace CovarianceAndContravariance
{
    class Covariance
    {
        static void Main(string[] args)
        {
            Student[] students =
            {
                new Student("John"),
                new Student("Peter")
            };

            PrintNames(students);

            // Update(students);
        }

        // This works because both Student and Teacher have names 
        // is ok to print them by passing Student[] or Teacher[]
        public static void PrintNames(Person[] people)
        {
            foreach (var person in people)
            {
                Console.WriteLine(person.Name);
            }
        }

        // Exception trying to change array of different type
        public static void Update(Person[] people)
        {
            people[0] = new Teacher("Paul");
        }
    }

    // Covariance
    // The generic type parameter T is said to be at an output position in this interface. 
    // Output positions are limited to function return values, property get accessors, and certain delegate positions.
    public interface IMyReadOnlyCollection<out T>
    {
        T GetElementAt(int index);
    }
}
