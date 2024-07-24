using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortLib.Person;

public class ComparerByDateSurnameName : IComparer<Person>
{
    public int Compare(Person x, Person y)
    {
        Support.Utiles.NullException(x, y);

        int dateCompare = x.DateOfBirth.CompareTo(y.DateOfBirth);
        if (dateCompare != 0)
        {
            return dateCompare;
        }

        int surnameCompare = string.Compare(x.Surname, y.Surname, StringComparison.OrdinalIgnoreCase);
        if (surnameCompare != 0)
        {
            return surnameCompare;
        }

        return string.Compare(x.Name, y.Name, StringComparison.OrdinalIgnoreCase);
    }
}
