namespace Swdac.ValidationFramework.Specifications
{
    public abstract class Specification<T> : ISpecification<T>
    {
        public virtual ISpecification<T> And(ISpecification<T> specification)
        {
            return new AndSpecification<T>(this, specification);
        }

        public virtual ISpecification<T> Or(ISpecification<T> specification)
        {
            return new OrSpecification<T>(this, specification);
        }

        public virtual ISpecification<T> Not(ISpecification<T> specification)
        {
            return new NotSpecification<T>(specification);
        }

        public virtual bool IsSatisfiedBy(T candidate)
        {
            return IsSatisfiedBy(candidate, null);
        }

        public abstract bool IsSatisfiedBy(T candidate, List<string>? notSatisfied);

        public virtual string SpecSatisfiedBy(T candidate)
        {
            // Se utiliza el nombre de la clase para identificar la especificación
            string spec = ToString();
            string[] parts = spec.Split('.');
            spec = parts[parts.Length - 1];
            spec = spec.Replace("Specification", "");
            int atIndex = spec.IndexOf('@');
            if (atIndex > 0)
            {
                spec = spec.Substring(0, atIndex);
            }
            return spec;
        }
    }
}

