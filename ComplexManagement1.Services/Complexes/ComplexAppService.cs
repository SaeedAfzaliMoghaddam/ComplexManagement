using ComplexManagement1.Entities;
using ComplexManagement1.Services.Complexes.Contracts;
using ComplexManagement1.Services.Complexes.Contracts.Dto;
using ComplexManagement1.Services.Complexes.Exceptions;
using ComplexManagement1.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexManagement1.Services.Complexes
{
    public class ComplexAppService : ComplexService
    {
        private readonly ComplexRepository _repository;
        private readonly UnitOfWork _unitOfWork;

        public ComplexAppService(ComplexRepository repository, UnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public void Add(AddComplexDto dto)
        {
            var complex = new Complex
            {
                Name = dto.Name,
                UnitCount = dto.UnitCount,
            };
            _repository.Add(complex);
            _unitOfWork.Complete();
        }

        public List<GetAllComplexesDto> GetAll()
        {
            return _repository.GetAll();
        }

        public List<GetAllComplexesWithUnitsdetailsDto> GetAllWithUnitsDetails(string? name = null)
        {
            return _repository.GetAllWithUnitsDetails(name);
        }

        public GetAComplexDto GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void Update(int id, int newUnitCount)
        {
            var complex = _repository.FindById(id);
            if (complex == null)
            {
                throw new ComplexNotFoundException();
            }

            complex.UnitCount = newUnitCount;
            _repository.Update(complex);
            _unitOfWork.Complete();
        }


    }
}
