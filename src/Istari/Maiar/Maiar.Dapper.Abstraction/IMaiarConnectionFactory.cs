using System.Data.Common;

namespace Maiar.Dapper.Abstraction;
public interface IMaiarConnectionFactory
{
	DbConnection Create(string connectionString);
}
