using Review;

namespace Exercise2Tests;

public class PeopleTests
{
    [Fact]
    public void People_Creation_Should_Set_Name_And_DOB()
    {
        // Arrange
        string name = "Alice";
        DateTime dob = DateTime.MaxValue;
        // Act
        var person = new Person(name, dob);
        // Assert
        Assert.Equal(name, person.Name);
        Assert.Equal(dob, person.DOB);
    }

    [Fact]
    public void People_Default_Creation_Should_Set_DOB_To_Under16()
    {
        // Arrange
        string name = "Charlie";
        // Act
        var person = new Person(name);
        // Assert
        Assert.Equal(name, person.Name);
        Assert.True(person.DOB <= DateTimeOffset.UtcNow.AddYears(-15));
    }
    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(50)]
    public void BirthingUnit_GetPeople_Should_Return_Correct_Type(int numberOfPeopleToCreate)
    {
        // Arrange
        var birthingUnit = new BirthingUnit(new FakeRepository());
        // Act
        var people = birthingUnit.GetPeople(numberOfPeopleToCreate);
        // Assert
        Assert.IsType<IEnumerable<Person>>(people, exactMatch: false);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(10)]
    public void BirthingUnit_GetPeople_Should_Return_Correct_Number_Of_People(int numberOfPeopleToCreate)
    {
        // Arrange
        var birthingUnit = new BirthingUnit(new FakeRepository());
        // Act
        var people = birthingUnit.GetPeople(numberOfPeopleToCreate);
        // Assert
        Assert.Equal(numberOfPeopleToCreate, people.Count());
    }
}
public class FakeRepository : IRepository
{
    private List<Person> _people = new List<Person>();
    public void AddPerson(Person person)
    {
        _people.Add(person);
    }
    public IEnumerable<Person> GetPeople(int maxItemsToRetrieve)
    {
        FakePeople(maxItemsToRetrieve);
        return _people.Take(maxItemsToRetrieve);
    }
    private void FakePeople(int maxItemsToRetrieve)
    {
        while (_people.Count < maxItemsToRetrieve)
        {
            try
            {
                // Creates a dandon Name
                string name = string.Empty;
                var random = new Random();
                if (random.Next(0, 1) == 0)
                {
                    name = "Bob";
                }
                else { name = "Betty"; }
                // Adds new people to the list
                AddPerson(new Person(name, DateTimeOffset.UtcNow.Subtract(new TimeSpan(random.Next(18, 85) * 356, 0, 0, 0))));
            }
            catch (Exception e)
            {
                // Dont think this should ever happen
                throw new Exception("Something failed in user creation");
            }

        }
    }

}