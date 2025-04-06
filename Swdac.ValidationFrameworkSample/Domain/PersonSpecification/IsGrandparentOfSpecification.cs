using Swdac.ValidationFramework.Specifications;
using System;
using System.Collections.Generic;

namespace Swdac.ValidationFrameworkSample.Domain.PersonSpecification
{
    public class IsGrandparentOfSpecification : Specification<Person>
    {
        private readonly Person _grandparent;

        public IsGrandparentOfSpecification(Person grandparent)
        {
            _grandparent = grandparent ?? throw new ArgumentNullException(nameof(grandparent));
        }

        public override bool IsSatisfiedBy(Person candidate)
        {
            return IsSatisfiedBy(candidate, null);
        }

        public override string SpecSatisfiedBy(Person candidate)
        {
            return IsSatisfiedBy(candidate) ? "Is a grandparent of the specified person" : "Is not a grandparent of the specified person";
        }

        public override bool IsSatisfiedBy(Person candidate, List<string>? notSatisfied)
        {
            if (candidate.Mother != null)
            {
                var isChildSpec = new IsChildOfSpecification(_grandparent);
                if (isChildSpec.IsSatisfiedBy(candidate.Mother))
                {
                    return true;
                }
            }

            if (candidate.Father != null)
            {
                var isChildSpec = new IsChildOfSpecification(_grandparent);
                if (isChildSpec.IsSatisfiedBy(candidate.Father))
                {
                    return true;
                }
            }

            if (notSatisfied != null)
            {
                notSatisfied.Add($"{_grandparent} is not a grandparent of the {candidate}.");
            }
            return false;
        }
    }
}
