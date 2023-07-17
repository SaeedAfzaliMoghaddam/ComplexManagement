using ComplexManagement1.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexManagement1.Persistance.EF.Units
{
    public class UnitEntityMap : IEntityTypeConfiguration<Unit>
    {
        public void Configure(EntityTypeBuilder<Unit> _)
        {
            _.ToTable("Units");
            _.HasKey("Id");
            _.Property(_ => _.Id)
                .ValueGeneratedOnAdd();
            _.Property(_ => _.Name)
                .IsRequired()
                .HasMaxLength(50);
            _.Property(_ => _.ResidenseType)
                .IsRequired();
            _.Property(_ => _.BlockId)
                .IsRequired();
            _.HasOne(_ => _.Block)
                .WithMany(_ => _.Units)
                .HasForeignKey(_ => _.BlockId);
        }
    }
}
