using SortLib.Support;

namespace SortLib.Person;

public class ComparerByName : IComparer<Person>
{
    public int Compare(Person x, Person y)
    {
        Utiles.NullException(x, y);
        return string.Compare(x.Name, y.Name, StringComparison.Ordinal);
    }
}

