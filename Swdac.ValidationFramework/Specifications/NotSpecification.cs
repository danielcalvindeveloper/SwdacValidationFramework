using System.Collections.Generic;

namespace Swdac.ValidationFramework.Specifications
{
    public class NotSpecification<T> : Specification<T>
    {
        private readonly ISpecification<T> _spec1;
        private bool _result;

        public NotSpecification(ISpecification<T> spec1)
        {
            _spec1 = spec1;
        }

        public override bool IsSatisfiedBy(T candidate)
        {
            return IsSatisfiedBy(candidate, null);
        }

        public override string SpecSatisfiedBy(T candidate)
        {
            return $"[not( {_spec1.SpecSatisfiedBy(candidate)} )]";
        }

        public override bool IsSatisfiedBy(T candidate, List<string>? notSatisfied)
        {
            _result = !_spec1.IsSatisfiedBy(candidate, notSatisfied);
            return _result;
        }
    }
}
