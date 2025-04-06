using System;
using Xunit;
using Swdac.ValidationFrameworkSample.Domain;
using Swdac.ValidationFrameworkSample.Domain.PersonSpecification;

namespace Swdac.ValidationFrameworkSample.Tests.Domain
{
    public class IsGrandparentOfSpecificationTests
    {
        [Fact]
        public void IsSatisfiedBy_ShouldReturnTrue_WhenPersonIsGrandparent()
        {
            // Arrange
            var grandparent = new Person(1, "John", "Doe", new DateTime(1950, 1, 1), GenderEnum.Masculine);
            var parent = new Person(2, "Jane", "Doe", new DateTime(1975, 1, 1), GenderEnum.Feminine);
            var child = new Person(3, "Alice", "Doe", new DateTime(2000, 1, 1), GenderEnum.Feminine);

            parent.setParents(grandparent, new Person(4, "Mary", "Doe", new DateTime(1955, 1, 1), GenderEnum.Feminine));
            child.setParents(parent, new Person(5, "Bob", "Smith", new DateTime(1975, 1, 1), GenderEnum.Masculine));

            var isGrandparentSpec = new IsGrandparentOfSpecification(grandparent);

            // Act
            bool result = isGrandparentSpec.IsSatisfiedBy(child);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void IsSatisfiedBy_ShouldReturnFalse_WhenPersonIsNotGrandparent()
        {
            // Arrange
            var grandparent = new Person(1, "John", "Doe", new DateTime(1950, 1, 1), GenderEnum.Masculine);
            var parent = new Person(2, "Jane", "Doe", new DateTime(1975, 1, 1), GenderEnum.Feminine);
            var child = new Person(3, "Alice", "Doe", new DateTime(2000, 1, 1), GenderEnum.Feminine);

            parent.setParents(new Person(4, "Mary", "Doe", new DateTime(1955, 1, 1), GenderEnum.Feminine), new Person(5, "Bob", "Smith", new DateTime(1950, 1, 1), GenderEnum.Masculine));
            child.setParents(parent, new Person(6, "Tom", "Smith", new DateTime(1975, 1, 1), GenderEnum.Masculine));

            var isGrandparentSpec = new IsGrandparentOfSpecification(grandparent);

            // Act
            bool result = isGrandparentSpec.IsSatisfiedBy(child);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void SpecSatisfiedBy_ShouldReturnCorrectMessage_WhenPersonIsGrandparent()
        {
            // Arrange
            var grandparent = new Person(1, "John", "Doe", new DateTime(1950, 1, 1), GenderEnum.Masculine);
            var parent = new Person(2, "Jane", "Doe", new DateTime(1975, 1, 1), GenderEnum.Feminine);
            var child = new Person(3, "Alice", "Doe", new DateTime(2000, 1, 1), GenderEnum.Feminine);

            parent.setParents(grandparent, new Person(4, "Mary", "Doe", new DateTime(1955, 1, 1), GenderEnum.Feminine));
            child.setParents(parent, new Person(5, "Bob", "Smith", new DateTime(1975, 1, 1), GenderEnum.Masculine));

            var isGrandparentSpec = new IsGrandparentOfSpecification(grandparent);

            // Act
            string result = isGrandparentSpec.SpecSatisfiedBy(child);

            // Assert
            Assert.Equal("Is a grandparent of the specified person", result);
        }

        [Fact]
        public void SpecSatisfiedBy_ShouldReturnCorrectMessage_WhenPersonIsNotGrandparent()
        {
            // Arrange
            var grandparent = new Person(1, "John", "Doe", new DateTime(1950, 1, 1), GenderEnum.Masculine);
            var parent = new Person(2, "Jane", "Doe", new DateTime(1975, 1, 1), GenderEnum.Feminine);
            var child = new Person(3, "Alice", "Doe", new DateTime(2000, 1, 1), GenderEnum.Feminine);

            parent.setParents(new Person(4, "Mary", "Doe", new DateTime(1955, 1, 1), GenderEnum.Feminine), new Person(5, "Bob", "Smith", new DateTime(1950, 1, 1), GenderEnum.Masculine));
            child.setParents(parent, new Person(6, "Tom", "Smith", new DateTime(1975, 1, 1), GenderEnum.Masculine));

            var isGrandparentSpec = new IsGrandparentOfSpecification(grandparent);

            // Act
            string result = isGrandparentSpec.SpecSatisfiedBy(child);

            // Assert
            Assert.Equal("Is not a grandparent of the specified person", result);
        }
    }
}
