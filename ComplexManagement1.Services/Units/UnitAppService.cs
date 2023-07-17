using ComplexManagement1.Entities;
using ComplexManagement1.Services.Contracts;
using ComplexManagement1.Services.Units.Contracts;
using ComplexManagement1.Services.Units.Contracts.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexManagement1.Services.Units
{
    public class UnitAppService : UnitService
    {
        private readonly UnitRepository _unitRepository;
        private readonly UnitOfWork _unitOfWork;

        public UnitAppService(UnitRepository unitRepository, UnitOfWork unitOfWork)
        {
            _unitRepository = unitRepository;
            _unitOfWork = unitOfWork;
        }

        public void Add(AddUnitsDto dto)
        {
            //todo exception duplicate
            var unit = new Unit
            {
                BlockId= dto.BlockId,
                Name= dto.Name,
                ResidenseType= dto.ResidenseType,
            };

            _unitRepository.Add(unit);
            _unitOfWork.Complete();
        }
    }
}
