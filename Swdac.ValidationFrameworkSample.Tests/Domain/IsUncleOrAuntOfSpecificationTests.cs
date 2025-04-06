using System;
using Xunit;
using Swdac.ValidationFrameworkSample.Domain;
using Swdac.ValidationFrameworkSample.Domain.PersonSpecification;

namespace Swdac.ValidationFrameworkSample.Tests.Domain
{
    public class IsUncleOrAuntOfSpecificationTests
    {
        [Fact]
        public void IsSatisfiedBy_ShouldReturnTrue_WhenPersonIsUncleOrAunt()
        {
            // Arrange
            var grandparent1 = new Person(1, "Grandpa", "Doe", new DateTime(1950, 1, 1), GenderEnum.Masculine);
            var grandparent2 = new Person(2, "Grandma", "Doe", new DateTime(1955, 1, 1), GenderEnum.Feminine);
            var parent = new Person(3, "Jane", "Doe", new DateTime(1975, 1, 1), GenderEnum.Feminine);
            var uncle = new Person(4, "John", "Doe", new DateTime(1970, 1, 1), GenderEnum.Masculine);
            var child = new Person(5, "Alice", "Doe", new DateTime(2000, 1, 1), GenderEnum.Feminine);

            parent.setParents(grandparent1, grandparent2);
            uncle.setParents(grandparent1, grandparent2);
            child.setParents(parent, new Person(6, "Tom", "Smith", new DateTime(1975, 1, 1), GenderEnum.Masculine));

            var isUncleOrAuntSpec = new IsUncleOrAuntOfSpecification(uncle);

            // Act
            bool result = isUncleOrAuntSpec.IsSatisfiedBy(child);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void IsSatisfiedBy_ShouldReturnFalse_WhenPersonIsNotUncleOrAunt()
        {
            // Arrange
            var grandparent1 = new Person(1, "Grandpa", "Doe", new DateTime(1950, 1, 1), GenderEnum.Masculine);
            var grandparent2 = new Person(2, "Grandma", "Doe", new DateTime(1955, 1, 1), GenderEnum.Feminine);
            var parent = new Person(3, "Jane", "Doe", new DateTime(1975, 1, 1), GenderEnum.Feminine);
            var nonUncle = new Person(4, "Charlie", "Smith", new DateTime(1970, 1, 1), GenderEnum.Masculine);
            var child = new Person(5, "Alice", "Doe", new DateTime(2000, 1, 1), GenderEnum.Feminine);

            parent.setParents(grandparent1, grandparent2);
            child.setParents(parent, new Person(6, "Tom", "Smith", new DateTime(1975, 1, 1), GenderEnum.Masculine));

            var isUncleOrAuntSpec = new IsUncleOrAuntOfSpecification(nonUncle);

            // Act
            bool result = isUncleOrAuntSpec.IsSatisfiedBy(child);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void SpecSatisfiedBy_ShouldReturnCorrectMessage_WhenPersonIsUncleOrAunt()
        {
            // Arrange
            var grandparent1 = new Person(1, "Grandpa", "Doe", new DateTime(1950, 1, 1), GenderEnum.Masculine);
            var grandparent2 = new Person(2, "Grandma", "Doe", new DateTime(1955, 1, 1), GenderEnum.Feminine);
            var parent = new Person(3, "Jane", "Doe", new DateTime(1975, 1, 1), GenderEnum.Feminine);
            var uncle = new Person(4, "John", "Doe", new DateTime(1970, 1, 1), GenderEnum.Masculine);
            var child = new Person(5, "Alice", "Doe", new DateTime(2000, 1, 1), GenderEnum.Feminine);

            parent.setParents(grandparent1, grandparent2);
            uncle.setParents(grandparent1, grandparent2);
            child.setParents(parent, new Person(6, "Tom", "Smith", new DateTime(1975, 1, 1), GenderEnum.Masculine));

            var isUncleOrAuntSpec = new IsUncleOrAuntOfSpecification(uncle);

            // Act
            string result = isUncleOrAuntSpec.SpecSatisfiedBy(child);

            // Assert
            Assert.Equal("Is an uncle or aunt of the specified person", result);
        }

        [Fact]
        public void SpecSatisfiedBy_ShouldReturnCorrectMessage_WhenPersonIsNotUncleOrAunt()
        {
            // Arrange
            var grandparent1 = new Person(1, "Grandpa", "Doe", new DateTime(1950, 1, 1), GenderEnum.Masculine);
            var grandparent2 = new Person(2, "Grandma", "Doe", new DateTime(1955, 1, 1), GenderEnum.Feminine);
            var parent = new Person(3, "Jane", "Doe", new DateTime(1975, 1, 1), GenderEnum.Feminine);
            var nonUncle = new Person(4, "Charlie", "Smith", new DateTime(1970, 1, 1), GenderEnum.Masculine);
            var child = new Person(5, "Alice", "Doe", new DateTime(2000, 1, 1), GenderEnum.Feminine);

            parent.setParents(grandparent1, grandparent2);
            child.setParents(parent, new Person(6, "Tom", "Smith", new DateTime(1975, 1, 1), GenderEnum.Masculine));

            var isUncleOrAuntSpec = new IsUncleOrAuntOfSpecification(nonUncle);

            // Act
            string result = isUncleOrAuntSpec.SpecSatisfiedBy(child);

            // Assert
            Assert.Equal("Is not an uncle or aunt of the specified person", result);
        }
    }
}


