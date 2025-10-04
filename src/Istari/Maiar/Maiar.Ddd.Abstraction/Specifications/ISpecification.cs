using Maiar.Resulting.Abstraction;

namespace Maiar.Ddd.Abstraction.Specifications;
public interface ISpecification<T>
{
	bool IsSatisfiedBy(T candidate);
	ISpecification<T> And(ISpecification<T> other) => new AndSpecification<T>(this, other);
	ISpecification<T> AndNot(ISpecification<T> other) => new AndNotSpecification<T>(this, other);
	ISpecification<T> Or(ISpecification<T> other) => new OrSpecification<T>(this, other);
	ISpecification<T> OrNot(ISpecification<T> other) => new OrNotSpecification<T>(this, other);
	ISpecification<T> Not() => new NotSpecification<T>(this);
}
