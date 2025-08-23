using Microsoft.EntityFrameworkCore;

namespace Sauron.Domain.EfCore;
// TODO: Make it internal
public sealed class SauronDbContext : DbContext
{
	public SauronDbContext(DbContextOptions<SauronDbContext> options) : base(options) { }
}
