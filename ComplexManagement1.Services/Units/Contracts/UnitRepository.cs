using ComplexManagement1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexManagement1.Services.Units.Contracts
{
    public interface UnitRepository
    {
        void Add(Unit unit);
        bool IsAssignedToComplex(int comlexId);
    }
}
