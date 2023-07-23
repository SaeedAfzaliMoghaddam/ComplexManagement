using ComplexManagement1.Entities;
using ComplexManagement1.Persistance.EF;
using ComplexManagement1.Services.Units.Contracts;
using Microsoft.EntityFrameworkCore;

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
}
