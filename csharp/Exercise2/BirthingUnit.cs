using System.Collections.Generic;

namespace Review;

public class BirthingUnit
{
    private readonly IRepository _repository;

    private BirthingUnit() {
    }
    public BirthingUnit(IRepository repository)
    {
        _repository = repository;
    }

    public IEnumerable<Person> GetPeople(int maxItemsToRetrieve)
    {
        return _repository.GetPeople(maxItemsToRetrieve);
    }
}