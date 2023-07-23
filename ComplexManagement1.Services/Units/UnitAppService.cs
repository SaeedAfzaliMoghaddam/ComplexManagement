using ComplexManagement1.Entities;
using ComplexManagement1.Services.Blocks.Contracts;
using ComplexManagement1.Services.Blocks.Exceptions;
using ComplexManagement1.Services.Contracts;
using ComplexManagement1.Services.Units.Contracts;
using ComplexManagement1.Services.Units.Contracts.Dto;

namespace ComplexManagement1.Services.Units
{
    public class UnitAppService : UnitService
    {
        private readonly UnitRepository _repository;
        private readonly UnitOfWork _unitOfWork;
        private readonly BlockRepository _blockRepository;
        public UnitAppService
            (
            UnitRepository repository,
            UnitOfWork unitOfWork,
            BlockRepository blockRepository
            )
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _blockRepository = blockRepository;
        }

        public void Add(AddUnitDto dto)
        {
            var nameIsDublicate = _blockRepository.CheckUnitName(dto.BlockId,dto.Name);

            if (nameIsDublicate)
            {
                throw new DublicateUnitNameException();
            }

            var blockExist =_blockRepository.IsExist(dto.BlockId);
            if (!blockExist) 
            {
                throw new BlockNotFoundException();
            }

            var unit = new Entities.Unit
            {
                Name = dto.Name,
                ResidenseType = dto.ResidenseType,
                BlockId = dto.BlockId,
            };

            _repository.Add(unit);
            _unitOfWork.Complete();
        }
    }
}