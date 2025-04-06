using System.Collections.Generic;

namespace Swdac.ValidationFramework.Specifications
{
    public class OrSpecification<T> : Specification<T>
    {
        private readonly ISpecification<T> _spec1;
        private readonly ISpecification<T> _spec2;

        public OrSpecification(ISpecification<T> spec1, ISpecification<T> spec2)
        {
            _spec1 = spec1;
            _spec2 = spec2;
        }

        public override bool IsSatisfiedBy(T candidate)
        {
            return IsSatisfiedBy(candidate, null);
        }

        public override string SpecSatisfiedBy(T candidate)
        {
            return $"[{_spec1.SpecSatisfiedBy(candidate)} or {_spec2.SpecSatisfiedBy(candidate)}]";
        }

        public override bool IsSatisfiedBy(T candidate, List<string>? notSatisfied)
        {
            bool r1 = _spec1.IsSatisfiedBy(candidate, notSatisfied);
            bool r2 = _spec2.IsSatisfiedBy(candidate, notSatisfied);
            return r1 || r2;
        }
    }
}
