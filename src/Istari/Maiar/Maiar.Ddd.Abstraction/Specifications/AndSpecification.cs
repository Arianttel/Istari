using Maiar.Resulting.Abstraction;

namespace Maiar.Ddd.Abstraction.Specifications;
public sealed class AndSpecification<T> : CompositeSpecification<T>
{
	public AndSpecification(ISpecification<T> left, ISpecification<T> right)
		: base(left, right) { }

	public override bool IsSatisfiedBy(T candidate)
		=> _left.IsSatisfiedBy(candidate) && _right.IsSatisfiedBy(candidate);
}
