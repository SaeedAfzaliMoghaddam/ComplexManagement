using ComplexManagement1.Entities;
using ComplexManagement1.Services.Blocks.Contracts.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexManagement1.Services.Blocks.Contracts
{
    public interface BlockRepository
    {
        void Add(Block block);
        List<GetAllBlocksDto> GetAll();
        //todo Id
        List<GetBlockByIdDto> GetByIDWithUnits(int id);



    }
}
