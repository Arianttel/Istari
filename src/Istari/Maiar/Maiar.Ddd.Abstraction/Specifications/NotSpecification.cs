using Maiar.Resulting.Abstraction;

namespace Maiar.Ddd.Abstraction.Specifications;
public sealed class NotSpecification<T> : ISpecification<T>
{
	public ISpecification<T> _specification;

	public NotSpecification(ISpecification<T> specification)
	{
		_specification = specification;
	}

	public bool IsSatisfiedBy(T candidate) => !_specification.IsSatisfiedBy(candidate);
}
