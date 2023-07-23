using ComplexManagement1.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexManagement1.Persistance.EF.Units
{
    public class UnitEnityMap : IEntityTypeConfiguration<Unit>
    {
        public void Configure(EntityTypeBuilder<Unit> entity)
        {
            entity.ToTable("Units");
            entity.HasKey(_ => _.Id);
            entity.Property(_ => _.Id)
                .ValueGeneratedOnAdd();
            entity.Property(_ => _.Name)
                .IsRequired();
            entity.Property(_ => _.BlockId)
                .IsRequired();
            entity.Property(_ => _.ResidenseType)
                .IsRequired();
        }
    }
}
