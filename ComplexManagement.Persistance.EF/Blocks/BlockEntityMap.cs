using ComplexManagement1.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexManagement1.Persistance.EF.Blocks
{
    public class BlockEntityMap : IEntityTypeConfiguration<Block>
    {
        public void Configure(EntityTypeBuilder<Block> _)
        {
            _.ToTable("Blocks");
            _.HasKey(_ => _.Id);
            _.Property(_ => _.Id)
                .ValueGeneratedOnAdd();
            _.Property(_ => _.UnitCount)
                .IsRequired();
            _.Property(_ => _.ComplexId)
                .IsRequired();
            _.HasOne(_ => _.Complex)
                .WithMany(_ => _.Blocks)
                .HasForeignKey(_ => _.ComplexId);
        }
    }
}
