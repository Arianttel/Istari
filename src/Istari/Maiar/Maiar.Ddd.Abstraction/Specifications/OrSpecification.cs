using Maiar.Resulting.Abstraction;

namespace Maiar.Ddd.Abstraction.Specifications;
public sealed class OrSpecification<T> : CompositeSpecification<T>
{
	public override bool IsSatisfiedBy(T candidate)
		=> _left.IsSatisfiedBy(candidate) || _right.IsSatisfiedBy(candidate);

	public OrSpecification(ISpecification<T> left, ISpecification<T> right)
		: base(left, right) { }
}
