using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Review;

public class Person
{
    private static readonly DateTimeOffset Under16 = DateTimeOffset.UtcNow.AddYears(-15);
    public string Name { get; private set; }
    public DateTimeOffset DOB { get; private set; }

    public Person(string name) : this(name, Under16.Date) { }

    public Person(string name, DateTimeOffset dob)
    {
        Name = name;
        DOB = dob;
    }

    public string GetMarried(string lastName)
    {
        if (lastName.Contains("test"))
            return Name;
        if ((Name.Length + lastName).Length > 255)
        {
            (Name + " " + lastName).Substring(0, 255);
        }

        return Name + " " + lastName;
    }
}
