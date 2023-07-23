using ComplexManagement1.Entities;

namespace ComplexManagement1.Services.Units.Contracts
{
    public interface UnitRepository
    {
        void Add(Entities.Unit unit);
    }
}