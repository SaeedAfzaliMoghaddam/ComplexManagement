using ComplexManagement1.Entities;
using ComplexManagement1.Services.Complexes.Contracts;
using ComplexManagement1.Services.Complexes.Contracts.Dto;
using ComplexManagement1.Services.Complexes.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexManagement1.Persistance.EF.Complexes
{
    public class EFComplexRepository : ComplexRepository
    {
        private readonly DbSet<Complex> _complexes;

        public EFComplexRepository(EFDataContext context)
        {
            _complexes = context.Set<Complex>();
        }

        public void Add(Complex complex)
        {
            _complexes.Add(complex);
            
        }



        //todo ?
        public Complex FindById(int id)
        {
            return _complexes.FirstOrDefault(_ => _.Id == id);
        }

        public List<GetAllComplexesDto> GetAll(SearchComplexDto dto)
        {
            var complexes = _complexes.Select(_ => new GetAllComplexesDto
            {
                Id = _.Id,
                Name = _.Name,
                FilledUnits = _.Blocks.SelectMany(_ => _.Units).Count(),
                RemainingUnits = _.UnitCount - _.Blocks.SelectMany(_ => _.Units).Count()
            });

            if (dto.Id != null)
            {
                complexes = complexes.Where(c => c.Id == dto.Id);
            }

            if (dto.Name != null)
            {
                complexes = complexes.Where(c => c.Name == dto.Name);
            }

            return complexes.ToList();
        }

        public List<GetAComplexDto> GetById(int id)
        {
            //todo 
            //var idExist = IdExist(id);
            //if (idExist != true)
            //{
            //    throw new ComplexNotFoundException();
            //}

            return _complexes.Where(_ => _.Id == id)
                .Select(_ => new GetAComplexDto
                {
                    Id = _.Id,
                    Name = _.Name,
                    FilledUnits = _.Blocks.SelectMany(_ => _.Units).Count(),
                    RemainingUnits = _.UnitCount - _.Blocks.SelectMany(_ => _.Units).Count(),
                    BlockCount = _.Blocks.Count()
                }).ToList();

        }

        public List<GetComplexByIdDto> GetByIdWithBlocks(int id)
        {
            //todo
            //var idExist = IdExist(id);
            //if (idExist != true)
            //{
            //    throw new ComplexNotFoundException();
            //}

            return _complexes
                .Where(_ => _.Id == id)
                .Select(_ => new GetComplexByIdDto
                {
                    Name = _.Name,
                    Blocks = _.Blocks
                    .Select(b => new GetBlocksOfComplexDto
                    {
                        Name = b.Name,
                        UnitCount = b.UnitCount,

                    })
                    .ToList(),
                })
                .ToList();
        }

        public bool IdExist(int id)
        {
            return _complexes.Any(_ => _.Id == id);
        }


    }
}
