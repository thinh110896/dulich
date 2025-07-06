using Tourism.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Tourism.Infrastructure.EntityConfigurations;

public class PredefineDataConfiguration : IEntityTypeConfiguration<PredefineData>
{
    public void Configure(EntityTypeBuilder<PredefineData> builder)
    {
        builder.ToTable("predefine_data");
    }
}
