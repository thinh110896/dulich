using Tourism.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Tourism.Infrastructure.EntityConfigurations;

public class AdministrativeDivisionConfiguration : IEntityTypeConfiguration<AdministrativeDivision>
{
    public void Configure(EntityTypeBuilder<AdministrativeDivision> builder)
    {
        builder.ToTable("administrative_division");
    }
}
