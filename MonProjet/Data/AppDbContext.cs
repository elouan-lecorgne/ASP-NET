using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public DbSet<Personne> Personnes { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
}
