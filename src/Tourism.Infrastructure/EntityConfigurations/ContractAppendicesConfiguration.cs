using Tourism.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Tourism.Infrastructure.EntityConfigurations;

public class ContractAppendicesConfiguration : IEntityTypeConfiguration<ContractAppendices>
{
    public void Configure(EntityTypeBuilder<ContractAppendices> builder)
    {
        builder.ToTable("contract_appendices");
    }
}
