using ComplexManagement1.Entities;
using ComplexManagement1.Services.Units.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexManagement1.Persistance.EF.Units
{
    public class EFUnitRepository : UnitRepository
    {
        private readonly DbSet<Unit> _units;

        public EFUnitRepository(EFDataContext context)
        {
            _units = context.Set<Unit>();
        }

        public void Add(Unit unit)
        {
            _units.Add(unit);
        }

        public bool IsAssignedToComplex(int complexId)
        {
            return _units.Any(_=>_.Block.ComplexId == complexId);
        }
    }
}
