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
        var person = new People(name, dob);
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
        var person = new People(name);
        // Assert
        Assert.Equal(name, person.Name);
        Assert.True(person.DOB <= DateTimeOffset.UtcNow.AddYears(-15));
    }
    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    public void BirthingUnit_GetPeople_Should_Return_Correct_Type(int numberOfPeopleToCreate)
    {
        // Arrange
        var birthingUnit = new BirthingUnit();
        // Act
        var people = birthingUnit.GetPeople(numberOfPeopleToCreate);
        // Assert
        Assert.IsType<List<People>>(people);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(10)]
    public void BirthingUnit_GetPeople_Should_Return_Correct_Number_Of_People(int numberOfPeopleToCreate)
    {
        // Arrange
        var birthingUnit = new BirthingUnit();
        // Act
        var people = birthingUnit.GetPeople(numberOfPeopleToCreate);
        // Assert
        Assert.Equal(numberOfPeopleToCreate, people.Count);
    }
}