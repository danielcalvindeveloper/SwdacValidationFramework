using Swdac.ValidationFramework.Specifications;
using System;
using System.Collections.Generic;

namespace Swdac.ValidationFrameworkSample.Domain.PersonSpecification
{
    public class IsUncleOrAuntOfSpecification : Specification<Person>
    {
        private readonly Person _uncleOrAunt;

        public IsUncleOrAuntOfSpecification(Person uncleOrAunt)
        {
            _uncleOrAunt = uncleOrAunt ?? throw new ArgumentNullException(nameof(uncleOrAunt));
        }

        public override bool IsSatisfiedBy(Person candidate)
        {
            return IsSatisfiedBy(candidate, null);
        }

        public override string SpecSatisfiedBy(Person candidate)
        {
            return IsSatisfiedBy(candidate) ? "Is an uncle or aunt of the specified person" : "Is not an uncle or aunt of the specified person";
        }

        public override bool IsSatisfiedBy(Person candidate, List<string>? notSatisfied)
        {
            if (candidate.Mother != null)
            {
                var isSiblingSpec = new IsSiblingOfSpecification(candidate.Mother);
                if (isSiblingSpec.IsSatisfiedBy(_uncleOrAunt))
                {
                    return true;
                }
            }

            if (candidate.Father != null)
            {
                var isSiblingSpec = new IsSiblingOfSpecification(candidate.Father);
                if (isSiblingSpec.IsSatisfiedBy(_uncleOrAunt))
                {
                    return true;
                }
            }

            if (notSatisfied != null)
            {
                notSatisfied.Add($"{_uncleOrAunt} is not an uncle or aunt of the {candidate}.");
            }
            return false;
        }
    }
}


