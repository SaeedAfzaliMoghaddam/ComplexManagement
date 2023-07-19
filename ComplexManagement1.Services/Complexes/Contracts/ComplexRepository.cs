using ComplexManagement1.Entities;
using ComplexManagement1.Services.Complexes.Contracts.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexManagement1.Services.Complexes.Contracts
{
    public interface ComplexRepository
    {
        void Add(Complex complex);
        List<GetAllComplexesDto> GetAll();
        Complex FindById(int id);
        void Update(Complex complex);
        List<GetAllComplexesWithUnitsdetailsDto> GetAllWithUnitsDetails(string? name = null);
        GetAComplexDto GetById(int id);
    }
}
