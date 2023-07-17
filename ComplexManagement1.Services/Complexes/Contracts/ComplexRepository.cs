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

        //ToDo IsExistById
        bool IdExist(int id);
        List<GetAllComplexesDto> GetAll(SearchComplexDto dto);
        List<GetAComplexDto> GetById(int id);
        List<GetComplexByIdDto> GetByIdWithBlocks(int id);
        Complex FindById(int id);






    }
}
