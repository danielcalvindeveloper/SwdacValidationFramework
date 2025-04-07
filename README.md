# SwdacValidationFramework

Swdac.ValidationFramework is a small .NET framework designed to implement business validations based on the Specification pattern.

## Overview

This framework provides a flexible and reusable way to define and combine business rules using specifications. It allows you to create complex validation logic by combining simple specifications with logical operators such as AND, OR, and NOT.

## Features

- **Specification Pattern**: Define business rules as specifications that can be easily combined and reused.
- **Logical Operators**: Combine specifications using AND, OR, and NOT operators to create complex validation logic.
- **Extensibility**: Easily extend the framework with custom specifications to meet your specific business needs.

## Getting Started

To get started with Swdac.ValidationFramework, clone the repository and open the solution in Visual Studio 2022. The solution includes sample code and unit tests to help you understand how to use the framework.

## Example

Here is a simple example of how to use the framework to validate if a person is an adult and if they are a parent of another person:

### C#
    using System;
    using Xunit;
    using Swdac.ValidationFrameworkSample.Domain;
    using Swdac.ValidationFrameworkSample.Domain.PersonSpecification;

    namespace Swdac.ValidationFrameworkSample.Tests.Domain.PersonSpecification
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
                Assert.Equal("Alice Doe is an uncle or aunt of John Doe", result);
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
                Assert.Equal("Alice Doe is not an uncle or aunt of Charlie Smith", result);
            }
        }
    }

## Console Output
Here is the console output generated by the example:

###
	Hello family!

	Creating the family and validating...
	Is Dario Calvo a parent of Fernando Calvo? False
	Is Dario Calvo a parent of Elena Balvin? False
	Are Fernando Calvo and Elena Balvin parents of Dario Calvo? True
	Is Dario Calvo a sibling of Maria Calvo? True
	Is Dario Calvo a sibling of Maria Calvo? False

	Validating with list of invalid...
	Is Dario Calvo a sibling of Maria Calvo and Fernando Calvo? False
	Is Dario Calvo a sibling of Maria Calvo and Elena Balvin? False
	Dario Calvo is not a sibling of the Fernando Calvo.
	Dario Calvo is not a sibling of the Elena Balvin.

	Validating return description of...
	Is Dario Calvo a sibling of Maria Calvo and Fernando Calvo? Maria Calvo is a sibling of Dario Calvo, Fernando Calvo is not a sibling of Dario Calvo
	Are Fernando Calvo and Elena Balvin parents of Dario Calvo? [Elena Balvin is parent of Dario Calvo and Fernando Calvo is parent of Dario Calvo]

