using Swdac.ValidationFramework.Specifications;
using System;
using System.Collections.Generic;

namespace Swdac.ValidationFrameworkSample.Domain.PersonSpecification
{
    public class IsParentOfSpecification : Specification<Person>
    {
        private readonly Person _parent;

        public IsParentOfSpecification(Person parent)
        {
            _parent = parent ?? throw new ArgumentNullException(nameof(parent));
        }

        public override bool IsSatisfiedBy(Person candidate)
        {
            return IsSatisfiedBy(candidate, null);
        }

        public override string SpecSatisfiedBy(Person candidate)
        {
            return IsSatisfiedBy(candidate) ? "Is a parent of the specified person" : "Is not a parent of the specified person";
        }

        public override bool IsSatisfiedBy(Person candidate, List<string>? notSatisfied)
        {
            bool isParent = candidate.Mother!=null &&  candidate.Mother == _parent ||
                 candidate.Father!=null && candidate.Father == _parent;
            if (!isParent && notSatisfied != null)
            {
                notSatisfied.Add("Person is not a parent of the specified person.");
            }
            return isParent;
        }
    }
}

