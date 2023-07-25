using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Templete.Persistanse.EF.Complexes
{
    public class ComplexEntityMap : IEntityTypeConfiguration<Complex>
    {
        public void Configure(EntityTypeBuilder<Complex> _)
        {
            _.ToTable("Complexes");
            _.HasKey(_ => _.Id);
            _.Property(_ => _.Id)
                .ValueGeneratedOnAdd();
            _.Property(_ => _.Name)
                .HasMaxLength(255)
                .IsRequired();
            _.Property(_ => _.UnitCapacity)
                .IsRequired();
        }
    }
}
