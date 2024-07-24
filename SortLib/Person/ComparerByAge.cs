using SortLib.Support;
namespace SortLib.Person;



    



public class ComparerByAge : IComparer<Person>
{
    public int Compare(Person x, Person y)
    {
        if (x is null || y is null)
        {
            Utiles.NullException(x, y);
        }
        int ageComparison = x.Age.CompareTo(y.Age);

        if (ageComparison != 0)
        {
            return ageComparison;
        }


        int monthComparison = x.DateOfBirth.Month.CompareTo(y.DateOfBirth.Month);

        if (monthComparison != 0)
        {
            return monthComparison;
        }


        return x.DateOfBirth.Day.CompareTo(y.DateOfBirth.Day);




    }
}


