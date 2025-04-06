using Swdac.ValidationFramework.Specifications;
using System;
using System.Collections.Generic;

namespace Swdac.ValidationFrameworkSample.Domain.PersonSpecification
{
    public class IsAdultSpecification : Specification<Person>
    {
        public override bool IsSatisfiedBy(Person candidate)
        {
            return IsSatisfiedBy(candidate, null);
        }

        public override string SpecSatisfiedBy(Person candidate)
        {
            return candidate.BirthDate.AddYears(21) <= DateTime.Now ? "Is an adult" : "Is not an adult";
        }

        public override bool IsSatisfiedBy(Person candidate, List<string>? notSatisfied)
        {
            bool isAdult = candidate.BirthDate.AddYears(21) <= DateTime.Now;
            if (!isAdult && notSatisfied != null)
            {
                notSatisfied.Add("Person is not an adult.");
            }
            return isAdult;
        }
    }
}

