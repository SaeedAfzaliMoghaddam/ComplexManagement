using ComplexManagement1.Entities;
using ComplexManagement1.Services.Complexes.Contracts;
using ComplexManagement1.Services.Complexes.Contracts.Dto;
using ComplexManagement1.Services.Complexes.Exceptions;
using ComplexManagement1.Services.Contracts;
using ComplexManagement1.Services.Units.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexManagement1.Services.Complexes
{
    public class ComplexAppService : ComplexService
    {
        private readonly ComplexRepository _complexRepository;
        private readonly UnitOfWork _unitOfWork;
        private readonly UnitRepository _unitRepository;

        public ComplexAppService
            (
            ComplexRepository complexRepository,
            UnitOfWork unitOfWork,
            UnitRepository unitRepository

            )
        {
            _complexRepository = complexRepository;
            _unitOfWork = unitOfWork;
            _unitRepository = unitRepository;
        }

        public void Add(AddComplexDto dto)
        {
            //ToDo var 
            Complex complex = new Complex
            {
                Name = dto.Name,
                UnitCount = dto.UnitCount,
            };

            _complexRepository.Add(complex);
            _unitOfWork.Complete();

        }

        public void EditUnitCount(int id,int newUnitCount)
        {
            var complex = _complexRepository.FindById(id);
            //Todo complex not found
            bool unitAsseigned = _unitRepository.IsAssignedToComplex(id);
            if (unitAsseigned)
            {
                throw new ComplexHaveUnitsException();
            }
            complex.UnitCount = newUnitCount;

            //Todo _complexRepository.Update(complex);
            _unitOfWork.Complete();
        }

        public List<GetAllComplexesDto> GetAll(SearchComplexDto dto)
        {
            return _complexRepository.GetAll(dto);
        }

        public List<GetAComplexDto> GetById(int id)
        {
            return _complexRepository.GetById(id);
        }

        public List<GetComplexByIdDto> GetByIdWithBlocks(int id)
        {
            return _complexRepository.GetByIdWithBlocks(id);
            
        }
    }
}
