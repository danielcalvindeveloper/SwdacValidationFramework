using System.Collections.Generic;

namespace Swdac.ValidationFramework.Specifications
{
    public interface ISpecification<T>
    {
        bool IsSatisfiedBy(T candidate);
        bool IsSatisfiedBy(T candidate, List<string>? notSatisfied);
        string SpecSatisfiedBy(T candidate);

        ISpecification<T> And(ISpecification<T> specification);
        ISpecification<T> Or(ISpecification<T> specification);
        ISpecification<T> Not(ISpecification<T> specification);
    }
}