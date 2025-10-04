using Maiar.Resulting.Abstraction;

namespace Maiar.Ddd.Abstraction.Specifications;
public abstract class CompositeSpecification<T> : ISpecification<T>
{
	protected ISpecification<T> _left;
	protected ISpecification<T> _right;

	protected CompositeSpecification(ISpecification<T> left, ISpecification<T> right)
	{
		_left = left;
		_right = right;
	}

	public abstract bool IsSatisfiedBy(T candidate);
}
