using Swdac.ValidationFramework.Specifications;
using System;
using System.Collections.Generic;

namespace Swdac.ValidationFrameworkSample.Domain.PersonSpecification
{
    public class IsSiblingOfSpecification : Specification<Person>
    {
        private readonly Person _sibling;

        public IsSiblingOfSpecification(Person sibling)
        {
            _sibling = sibling ?? throw new ArgumentNullException(nameof(sibling));
        }

        public override bool IsSatisfiedBy(Person candidate)
        {
            return IsSatisfiedBy(candidate, null);
        }

        public override string SpecSatisfiedBy(Person candidate)
        {
            return _sibling.Mother == candidate.Mother && _sibling.Father == candidate.Father ? $"{candidate} is a sibling of {_sibling}" : $"{candidate} is not a sibling of {_sibling}";
        }

        public override bool IsSatisfiedBy(Person candidate, List<string>? notSatisfied)
        {
            bool isSibling = _sibling.Mother!=null &&  _sibling.Mother == candidate.Mother &&
                _sibling.Father != null &&_sibling.Father == candidate.Father;
            if (!isSibling && notSatisfied != null)
            {
                notSatisfied.Add($"{_sibling} is not a sibling of the {candidate}.");
            }
            return isSibling;
        }
    }
}
