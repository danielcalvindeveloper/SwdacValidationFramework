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
    using Swdac.ValidationFrameworkSample.Domain;
    using Swdac.ValidationFrameworkSample.Domain.PersonSpecification;
    namespace Swdac.ValidationFramework.Sample;


    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello family!");

            Person fc = new(1, "Fernando", "Calvo", new DateTime(1929, 05, 25), GenderEnum.Masculine);
            Person eb = new(2, "Elena", "Balvin", new DateTime(1935, 03, 15), GenderEnum.Feminine);

            Person dc = new(3, "Dario", "Calvo", new DateTime(1960, 07, 20), GenderEnum.Masculine);
            dc.setParents(eb, fc);

            IsParentOfSpecification isParentSpec = new(dc);
            Console.WriteLine($"Is {dc} a parent of {fc}? {isParentSpec.IsSatisfiedBy(eb)}");
            Console.WriteLine($"Is {dc} a parent of {eb}? {isParentSpec.IsSatisfiedBy(eb)}");

            IsParentOfSpecification isFatherSpec = new(fc);
            IsParentOfSpecification isMotherSpec = new(eb);
            Console.WriteLine($"Are {fc} and {eb} parents of {dc}?" +
                $" {isMotherSpec.And(isFatherSpec).IsSatisfiedBy(dc)}" );

            Person mfc = new(4, "Maria", "Calvo", new DateTime(1990, 01, 01), GenderEnum.Feminine);
            Person sc = new(5, "Silvia","Calvo", new DateTime(1990, 01, 01), GenderEnum.Feminine);

            mfc.setParents(eb, fc);
            sc.setParents(eb, fc);

            IsSiblingOfSpecification isSiblingSpec = new(dc);
            Console.WriteLine($"Is {dc} a sibling of {mfc}? " +
                $"{isSiblingSpec.IsSatisfiedBy(mfc) && isSiblingSpec.IsSatisfiedBy(sc) }");

        }
    }





