using ComplexManagement1.Services.Units.Contracts.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexManagement1.Services.Units.Contracts
{
    public interface UnitService
    {
        void Add(AddUnitsDto dto);
    }
}
