using Swdac.ValidationFrameworkSample.Domain;

namespace Swdac.ValidationFrameworkSample.Tests.Domain
{
    public class PersonTests
    {
        [Fact]
        public void Constructor_ShouldInitializeProperties()
        {
            // Arrange
            int id = 1;
            string name = "John";
            string surname = "Doe";
            DateTime birthDate = new DateTime(1990, 1, 1);
            GenderEnum gender = GenderEnum.Masculine;

            // Act
            Person person = new Person(id, name, surname, birthDate, gender);

            // Assert
            Assert.Equal(id, person.Id);
            Assert.Equal(name, person.Name);
            Assert.Equal(surname, person.Surname);
            Assert.Equal(birthDate, person.BirthDate);
            Assert.Equal(gender, person.gender);
        }
    }
}