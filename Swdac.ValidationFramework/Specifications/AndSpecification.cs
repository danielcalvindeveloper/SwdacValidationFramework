using System.Collections.Generic;

namespace Swdac.ValidationFramework.Specifications
{
    public class AndSpecification<T> : Specification<T>
    {
        private readonly ISpecification<T> _spec1;
        private readonly ISpecification<T> _spec2;

        public AndSpecification(ISpecification<T> spec1, ISpecification<T> spec2)
        {
            _spec1 = spec1;
            _spec2 = spec2;
        }

        public override string SpecSatisfiedBy(T candidate)
        {
            string s1 = _spec1.SpecSatisfiedBy(candidate);
            string s2 = _spec2.SpecSatisfiedBy(candidate);
            return $"[{s1} and {s2}]";
        }

        public override bool IsSatisfiedBy(T candidate)
        {
            return IsSatisfiedBy(candidate, null);
        }

        public override bool IsSatisfiedBy(T candidate, List<string>? notSatisfied)
        {
            bool result1 = _spec1.IsSatisfiedBy(candidate, notSatisfied);
            bool result2 = _spec2.IsSatisfiedBy(candidate, notSatisfied);
            return result1 && result2;
        }
    }
}
