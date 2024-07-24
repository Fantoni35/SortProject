using SortLib.Support;

namespace SortLib.Person
{
    public class ComparerByReverseSurname : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            Utiles.NullException(x,y);
            return string.Compare(y.Surname, x.Surname, StringComparison.OrdinalIgnoreCase);

        }
    }
}
