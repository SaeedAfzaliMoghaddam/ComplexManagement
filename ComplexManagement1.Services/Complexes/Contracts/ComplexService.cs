using ComplexManagement1.Entities;
using ComplexManagement1.Services.Complexes.Contracts.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexManagement1.Services.Complexes.Contracts
{
    public interface ComplexService
    {
        void Add(AddComplexDto dto);
        List<GetAllComplexesDto> GetAll();
        void Update(int id ,int newUnitCount);
        List<GetAllComplexesWithUnitsdetailsDto> GetAllWithUnitsDetails(string? name = null);
        GetAComplexDto GetById(int id);
    }
}
