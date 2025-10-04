using Maiar.Resulting.Abstraction;

namespace Maiar.Ddd.Abstraction.Specifications;
public sealed class AndNotSpecification<T> : CompositeSpecification<T>
{
	public AndNotSpecification(ISpecification<T> left, ISpecification<T> right)
		: base(left, right) { }

	public override bool IsSatisfiedBy(T candidate)
		=> _left.IsSatisfiedBy(candidate) && !_right.IsSatisfiedBy(candidate);
}
