using System.Collections.Generic;

namespace Review;
public interface IRepository
{
    IEnumerable<Person> GetPeople(int maxItemsToRetrieve);
    void AddPerson(Person person);
}
