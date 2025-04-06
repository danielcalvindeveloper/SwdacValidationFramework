using System;
using Xunit;
using Swdac.ValidationFrameworkSample.Domain;
using Swdac.ValidationFrameworkSample.Domain.PersonSpecification;

namespace Swdac.ValidationFrameworkSample.Tests.Domain.PersonSpecification
{
    public class IsChildOfSpecificationTests
    {
        [Fact]
        public void IsSatisfiedBy_ShouldReturnTrue_WhenPersonIsChild()
        {
            // Arrange
            var mother = new Person(1, "Jane", "Doe", new DateTime(1975, 1, 1), GenderEnum.Feminine);
            var father = new Person(2, "John", "Doe", new DateTime(1970, 1, 1), GenderEnum.Masculine);
            var child = new Person(3, "Alice", "Doe", new DateTime(2000, 1, 1), GenderEnum.Feminine);

            child.setParents(mother, father);

            var isChildSpec = new IsChildOfSpecification(mother);

            // Act
            bool result = isChildSpec.IsSatisfiedBy(child);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void IsSatisfiedBy_ShouldReturnFalse_WhenPersonIsNotChild()
        {
            // Arrange
            var mother = new Person(1, "Jane", "Doe", new DateTime(1975, 1, 1), GenderEnum.Feminine);
            var father = new Person(2, "John", "Doe", new DateTime(1970, 1, 1), GenderEnum.Masculine);
            var child = new Person(3, "Alice", "Doe", new DateTime(2000, 1, 1), GenderEnum.Feminine);
            var nonChild = new Person(4, "Charlie", "Smith", new DateTime(2002, 1, 1), GenderEnum.Masculine);

            child.setParents(mother, father);

            var isChildSpec = new IsChildOfSpecification(mother);

            // Act
            bool result = isChildSpec.IsSatisfiedBy(nonChild);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void SpecSatisfiedBy_ShouldReturnCorrectMessage_WhenPersonIsChild()
        {
            // Arrange
            var mother = new Person(1, "Jane", "Doe", new DateTime(1975, 1, 1), GenderEnum.Feminine);
            var father = new Person(2, "John", "Doe", new DateTime(1970, 1, 1), GenderEnum.Masculine);
            var child = new Person(3, "Alice", "Doe", new DateTime(2000, 1, 1), GenderEnum.Feminine);

            child.setParents(mother, father);

            var isChildSpec = new IsChildOfSpecification(mother);

            // Act
            string result = isChildSpec.SpecSatisfiedBy(child);

            // Assert
            Assert.Equal("Is a child of the specified parent", result);
        }

        [Fact]
        public void SpecSatisfiedBy_ShouldReturnCorrectMessage_WhenPersonIsNotChild()
        {
            // Arrange
            var mother = new Person(1, "Jane", "Doe", new DateTime(1975, 1, 1), GenderEnum.Feminine);
            var father = new Person(2, "John", "Doe", new DateTime(1970, 1, 1), GenderEnum.Masculine);
            var child = new Person(3, "Alice", "Doe", new DateTime(2000, 1, 1), GenderEnum.Feminine);
            var nonChild = new Person(4, "Charlie", "Smith", new DateTime(2002, 1, 1), GenderEnum.Masculine);

            child.setParents(mother, father);

            var isChildSpec = new IsChildOfSpecification(mother);

            // Act
            string result = isChildSpec.SpecSatisfiedBy(nonChild);

            // Assert
            Assert.Equal("Is not a child of the specified parent", result);
        }
    }
}
