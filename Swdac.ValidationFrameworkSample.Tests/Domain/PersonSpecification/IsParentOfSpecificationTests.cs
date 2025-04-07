using System;
using Xunit;
using Swdac.ValidationFrameworkSample.Domain;
using Swdac.ValidationFrameworkSample.Domain.PersonSpecification;

namespace Swdac.ValidationFrameworkSample.Tests.Domain.PersonSpecification
{
    public class IsParentOfSpecificationTests
    {
        [Fact]
        public void IsSatisfiedBy_ShouldReturnTrue_WhenPersonIsParent()
        {
            // Arrange
            var parent = new Person(1, "Jane", "Doe", new DateTime(1975, 1, 1), GenderEnum.Feminine);
            var child = new Person(2, "Alice", "Doe", new DateTime(2000, 1, 1), GenderEnum.Feminine);

            child.setParents(parent, new Person(3, "John", "Doe", new DateTime(1970, 1, 1), GenderEnum.Masculine));

            var isParentSpec = new IsParentOfSpecification(parent);

            // Act
            bool result = isParentSpec.IsSatisfiedBy(child);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void IsSatisfiedBy_ShouldReturnFalse_WhenPersonIsNotParent()
        {
            // Arrange
            var parent = new Person(1, "Jane", "Doe", new DateTime(1975, 1, 1), GenderEnum.Feminine);
            var child = new Person(2, "Alice", "Doe", new DateTime(2000, 1, 1), GenderEnum.Feminine);

            child.setParents(new Person(3, "Mary", "Smith", new DateTime(1975, 1, 1), GenderEnum.Feminine), new Person(4, "John", "Doe", new DateTime(1970, 1, 1), GenderEnum.Masculine));

            var isParentSpec = new IsParentOfSpecification(parent);

            // Act
            bool result = isParentSpec.IsSatisfiedBy(child);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void SpecSatisfiedBy_ShouldReturnCorrectMessage_WhenPersonIsParent()
        {
            // Arrange
            var parent = new Person(1, "Jane", "Doe", new DateTime(1975, 1, 1), GenderEnum.Feminine);
            var child = new Person(2, "Alice", "Doe", new DateTime(2000, 1, 1), GenderEnum.Feminine);

            child.setParents(parent, new Person(3, "John", "Doe", new DateTime(1970, 1, 1), GenderEnum.Masculine));

            var isParentSpec = new IsParentOfSpecification(parent);

            // Act
            string result = isParentSpec.SpecSatisfiedBy(child);

            // Assert
            Assert.Equal("Jane Doe is parent of Alice Doe", result);
        }

        [Fact]
        public void SpecSatisfiedBy_ShouldReturnCorrectMessage_WhenPersonIsNotParent()
        {
            // Arrange
            var parent = new Person(1, "Jane", "Doe", new DateTime(1975, 1, 1), GenderEnum.Feminine);
            var child = new Person(2, "Alice", "Doe", new DateTime(2000, 1, 1), GenderEnum.Feminine);

            child.setParents(new Person(3, "Mary", "Smith", new DateTime(1975, 1, 1), GenderEnum.Feminine), new Person(4, "John", "Doe", new DateTime(1970, 1, 1), GenderEnum.Masculine));

            var isParentSpec = new IsParentOfSpecification(parent);

            // Act
            string result = isParentSpec.SpecSatisfiedBy(child);

            // Assert
            Assert.Equal("Jane Doe is not parent of Alice Doe", result);
        }
    }
}

