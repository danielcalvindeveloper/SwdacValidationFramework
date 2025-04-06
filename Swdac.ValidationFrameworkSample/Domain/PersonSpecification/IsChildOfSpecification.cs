using Swdac.ValidationFramework.Specifications;
using System;
using System.Collections.Generic;

namespace Swdac.ValidationFrameworkSample.Domain.PersonSpecification
{
    public class IsChildOfSpecification : Specification<Person>
    {
        private readonly Person _parent;

        public IsChildOfSpecification(Person parent)
        {
            _parent = parent ?? throw new ArgumentNullException(nameof(parent));
        }

        public override bool IsSatisfiedBy(Person candidate)
        {
            return IsSatisfiedBy(candidate, null);
        }

        public override string SpecSatisfiedBy(Person candidate)
        {
            return _parent.Children.Contains(candidate) ? "Is a child of the specified parent" : "Is not a child of the specified parent";
        }

        public override bool IsSatisfiedBy(Person candidate, List<string>? notSatisfied)
        {
            bool isChild = _parent.Children.Contains(candidate);
            if (!isChild && notSatisfied != null)
            {
                notSatisfied.Add($"{candidate} is not a child of the {_parent}.");
            }
            return isChild;
        }
    }
}
