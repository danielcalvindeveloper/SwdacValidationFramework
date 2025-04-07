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
            return IsSatisfiedBy(candidate) ? $"{_parent} is parent of {candidate}" : $"{_parent} is not parent of {candidate}";
        }

        public override bool IsSatisfiedBy(Person candidate, List<string>? notSatisfied)
        {
            bool isParent = candidate.Mother!=null &&  candidate.Mother == _parent ||
                 candidate.Father!=null && candidate.Father == _parent;
            if (!isParent && notSatisfied != null)
            {
                notSatisfied.Add($"{_parent} is not a parent of the {candidate}.");
            }
            return isParent;
        }
    }
}

