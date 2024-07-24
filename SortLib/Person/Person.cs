
using System;
using System.Collections.Generic;

namespace SortLib.Person
{
    public class Person : IComparable<Person>
    {
        public static void SortWithIComparable<T>(T[] array) where T : IComparable<T>
        {
            Array.Sort(array);
        }

        public string Name { get; }
        public string Surname { get; }
        public DateTime DateOfBirth { get; }

        public Person(string name, string surname, DateTime dateOfBirth)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Surname = surname ?? throw new ArgumentNullException(nameof(surname));
            DateOfBirth = dateOfBirth;
        }

        public int CompareTo(Person person)
        {
            if (person is null)
            {
                throw new ArgumentNullException(nameof(person));
            }

            int nameCompare = Name.CompareTo(person.Name);
            if (nameCompare != 0)
            {
                return nameCompare;
            }

            int surnameCompare = Surname.CompareTo(person.Surname);
            if (surnameCompare != 0)
            {
                return surnameCompare;
            }

            return DateOfBirth.CompareTo(person.DateOfBirth);
        }

        public int Age
        {
            get
            {

                var today = DateTime.Today;
                var age = today.Year - DateOfBirth.Year;

                if (DateOfBirth.Date > today.AddYears(-age))
                {
                    age--;
                }

                return age;
            }
            
        }
    }
}