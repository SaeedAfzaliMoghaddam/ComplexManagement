using ComplexManagement1.Entities;
using ComplexManagement1.Services.Blocks.Contracts;
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

        public bool CheckUnitName(int id, string unitName)
        {
            var nameExist = _blocks.Where(_=>_.Id == id).Any(_=>_.Name== unitName);
            return nameExist;
        }

        public bool IsExist(int id)
        {
            return _blocks.Any(_=>_.Id == id);
        }
    }
}
