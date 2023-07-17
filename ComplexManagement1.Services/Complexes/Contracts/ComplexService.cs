using ComplexManagement1.Services.Complexes.Contracts.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexManagement1.Services.Complexes.Contracts
{
    public interface ComplexService
    {
        void Add(AddComplexDto dto);
        List<GetAllComplexesDto> GetAll(SearchComplexDto dto);
        List<GetAComplexDto> GetById(int id);
        List<GetComplexByIdDto> GetByIdWithBlocks(int id);
        void EditUnitCount(int id,int newUnitCount);

    }
}
