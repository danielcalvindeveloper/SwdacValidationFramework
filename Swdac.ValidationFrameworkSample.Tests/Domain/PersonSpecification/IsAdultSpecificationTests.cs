using System;
using Xunit;
using Swdac.ValidationFrameworkSample.Domain;
using Swdac.ValidationFrameworkSample.Domain.PersonSpecification;

namespace Swdac.ValidationFrameworkSample.Tests.Domain.PersonSpecification
{
    public class IsAdultSpecificationTests
    {
        [Fact]
        public void IsSatisfiedBy_ShouldReturnTrue_WhenPersonIsAdult()
        {
            // Arrange
            var person = new Person(1, "John", "Doe", new DateTime(2000, 1, 1), GenderEnum.Masculine);
            var isAdultSpec = new IsAdultSpecification();

            // Act
            bool result = isAdultSpec.IsSatisfiedBy(person);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void IsSatisfiedBy_ShouldReturnFalse_WhenPersonIsNotAdult()
        {
            // Arrange
            var person = new Person(1, "Jane", "Doe", new DateTime(2010, 1, 1), GenderEnum.Feminine);
            var isAdultSpec = new IsAdultSpecification();

            // Act
            bool result = isAdultSpec.IsSatisfiedBy(person);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void SpecSatisfiedBy_ShouldReturnCorrectMessage_WhenPersonIsAdult()
        {
            // Arrange
            var person = new Person(1, "John", "Doe", new DateTime(2000, 1, 1), GenderEnum.Masculine);
            var isAdultSpec = new IsAdultSpecification();

            // Act
            string result = isAdultSpec.SpecSatisfiedBy(person);

            // Assert
            Assert.Equal("Is an adult", result);
        }

        [Fact]
        public void SpecSatisfiedBy_ShouldReturnCorrectMessage_WhenPersonIsNotAdult()
        {
            // Arrange
            var person = new Person(1, "Jane", "Doe", new DateTime(2010, 1, 1), GenderEnum.Feminine);
            var isAdultSpec = new IsAdultSpecification();

            // Act
            string result = isAdultSpec.SpecSatisfiedBy(person);

            // Assert
            Assert.Equal("Is not an adult", result);
        }
    }
}

