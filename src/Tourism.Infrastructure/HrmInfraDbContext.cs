using Tourism.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Tourism.Infrastructure;

public class TourismDbContext(DbContextOptions<TourismDbContext> options) : DbContext(options)
{
    public DbSet<PredefineData> PredefineDatas { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<JobTitle> Titles { get; set; }
    public DbSet<JobPosition> Positions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TourismDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
