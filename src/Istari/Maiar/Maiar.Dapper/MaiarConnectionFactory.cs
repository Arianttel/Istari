using Maiar.Dapper.Abstraction;
using Npgsql;
using System.Data.Common;

namespace Maiar.Dapper;
internal sealed class MaiarConnectionFactory : IMaiarConnectionFactory
{
	public DbConnection Create(string connectionString)
	{
		return new NpgsqlConnection(connectionString);
	}
}
