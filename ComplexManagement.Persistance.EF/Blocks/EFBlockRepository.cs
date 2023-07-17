using ComplexManagement1.Entities;
using ComplexManagement1.Services.Blocks.Contracts;
using ComplexManagement1.Services.Blocks.Contracts.Dto;
using ComplexManagement1.Services.Blocks.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexManagement1.Persistance.EF.Blocks
{
    public class EFBlockRepository : BlockRepository
    {
        private readonly DbSet<Block> _blocks;

        public EFBlockRepository(EFDataContext context)
        {
            _blocks = context.Set<Block>();
        }

        public void Add(Block block)
        {
            _blocks.Add(block);
        }

        public List<GetAllBlocksDto> GetAll()
        {
            return _blocks
                .Select(_ => new GetAllBlocksDto
                {
                    Name = _.Name,
                    UnitCount = _.UnitCount,
                    FilledUnits = _.Units.Count(),
                    RemainedUnits = _.UnitCount - _.Units.Count(),
                })
                .ToList();
        }

        public List<GetBlockByIdDto> GetByIDWithUnits(int id)
        {
            return _blocks.Where(_ => _.Id == id)
                .Select(_ => new GetBlockByIdDto
                {
                    Name = _.Name,
                    Units = _.Units.Select(u => new GetUnitsOfBlockDto
                    {
                        Name = u.Name,
                        //todo return id
                        ResidenseType = u.ResidenseType.ToString(),
                    }).ToList(),

                }).ToList();


        }
    }
}
