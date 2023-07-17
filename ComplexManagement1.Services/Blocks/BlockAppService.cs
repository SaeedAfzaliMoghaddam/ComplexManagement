using ComplexManagement1.Entities;
using ComplexManagement1.Services.Blocks.Contracts;
using ComplexManagement1.Services.Blocks.Contracts.Dto;
using ComplexManagement1.Services.Complexes.Contracts;
using ComplexManagement1.Services.Complexes.Contracts.Dto;
using ComplexManagement1.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexManagement1.Services.Blocks
{
    public class BlockAppService : BlockService
    {
        private readonly BlockRepository _blockRepository;
        private readonly UnitOfWork _unitOfWork;

        public BlockAppService(
            BlockRepository blockRepository,
            UnitOfWork unitOfWork)
        {
            _blockRepository = blockRepository;
            _unitOfWork = unitOfWork;
        }

        public void Add(AddBlockDto dto)
        {
            //todo exception duplicate name
            var block = new Block
            {
                Name = dto.Name,
                UnitCount = dto.UnitCount,
                ComplexId = dto.ComplexId,
            };

            _blockRepository.Add(block);
            _unitOfWork.Complete();

        }

        public List<GetAllBlocksDto> GetAll()
        {
            return _blockRepository.GetAll();
        }

        public List<GetBlockByIdDto> GetByIDWithUnits(int id)
        {
            return _blockRepository.GetByIDWithUnits(id);
        }
    }
}
