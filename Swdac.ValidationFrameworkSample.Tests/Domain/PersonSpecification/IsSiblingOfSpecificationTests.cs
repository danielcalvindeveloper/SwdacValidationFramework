using System;
using Xunit;
using Swdac.ValidationFrameworkSample.Domain;
using Swdac.ValidationFrameworkSample.Domain.PersonSpecification;

namespace Swdac.ValidationFrameworkSample.Tests.Domain.PersonSpecification
{
    public class IsSiblingOfSpecificationTests
    {
        [Fact]
        public void IsSatisfiedBy_ShouldReturnTrue_WhenPersonIsSibling()
        {
            // Arrange
            var parent1 = new Person(1, "John", "Doe", new DateTime(1970, 1, 1), GenderEnum.Masculine);
            var parent2 = new Person(2, "Jane", "Doe", new DateTime(1975, 1, 1), GenderEnum.Feminine);
            var sibling1 = new Person(3, "Alice", "Doe", new DateTime(2000, 1, 1), GenderEnum.Feminine);
            var sibling2 = new Person(4, "Bob", "Doe", new DateTime(2002, 1, 1), GenderEnum.Masculine);

            sibling1.setParents(parent1, parent2);
            sibling2.setParents(parent1, parent2);

            var isSiblingSpec = new IsSiblingOfSpecification(sibling1);

            // Act
            bool result = isSiblingSpec.IsSatisfiedBy(sibling2);

            // Assert
            Assert.True(result);
        }


        [Fact]
        public void SpecSatisfiedBy_ShouldReturnCorrectMessage_WhenPersonIsSibling()
        {
            // Arrange
            var parent1 = new Person(1, "John", "Doe", new DateTime(1970, 1, 1), GenderEnum.Masculine);
            var parent2 = new Person(2, "Jane", "Doe", new DateTime(1975, 1, 1), GenderEnum.Feminine);
            var sibling1 = new Person(3, "Alice", "Doe", new DateTime(2000, 1, 1), GenderEnum.Feminine);
            var sibling2 = new Person(4, "Bob", "Doe", new DateTime(2002, 1, 1), GenderEnum.Masculine);

            sibling1.setParents(parent1, parent2);
            sibling2.setParents(parent1, parent2);

            var isSiblingSpec = new IsSiblingOfSpecification(sibling1);

            // Act
            string result = isSiblingSpec.SpecSatisfiedBy(sibling2);

            // Assert
            Assert.Equal("Is a sibling of the specified person", result);
        }

        [Fact]
        public void SpecSatisfiedBy_ShouldReturnCorrectMessage_WhenPersonIsNotSibling()
        {
            // Arrange
            var parent1 = new Person(1, "John", "Doe", new DateTime(1970, 1, 1), GenderEnum.Masculine);
            var parent2 = new Person(2, "Jane", "Doe", new DateTime(1975, 1, 1), GenderEnum.Feminine);
            var sibling1 = new Person(3, "Alice", "Doe", new DateTime(2000, 1, 1), GenderEnum.Feminine);
            var nonSibling = new Person(4, "Charlie", "Smith", new DateTime(2002, 1, 1), GenderEnum.Masculine);

            sibling1.setParents(parent1, parent2);

            var isSiblingSpec = new IsSiblingOfSpecification(sibling1);

            // Act
            string result = isSiblingSpec.SpecSatisfiedBy(nonSibling);

            // Assert
            Assert.Equal("Is not a sibling of the specified person", result);
        }
    }
}

