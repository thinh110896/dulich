using Tourism.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Tourism.Infrastructure.EntityConfigurations;

public class ContractTypesConfiguration : IEntityTypeConfiguration<ContractTypes>
{
    public void Configure(EntityTypeBuilder<ContractTypes> builder)
    {
        builder.ToTable("contract_types");
    }
}
