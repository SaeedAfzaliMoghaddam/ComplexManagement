using ComplexManagement1.Entities;
using ComplexManagement1.Services.Complexes.Contracts;
using ComplexManagement1.Services.Complexes.Contracts.Dto;
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

        public Complex FindById(int id)
        {
            return _complexes.FirstOrDefault(_ => _.Id == id);
        }

        public List<GetAllComplexesDto> GetAll()
        {
            return _complexes
                .Select(_ => new GetAllComplexesDto
                {
                    Id = _.Id,
                    Name = _.Name,
                    UnitCount = _.UnitCount,
                })
                .ToList();
        }

        public List<GetAllComplexesWithUnitsdetailsDto> GetAllWithUnitsDetails(string? name = null)
        {
            var c = _complexes.Select(_ => new GetAllComplexesWithUnitsdetailsDto
            {
                Id = _.Id,
                Name = _.Name,
                FilledUnitCount = _.Blocks.SelectMany(_ => _.Units).Count(),
                RemainingUnitCount = _.UnitCount - _.Blocks.SelectMany(_ => _.Units).Count()

            });
            if (name!=null)
            {
                c = c.Where(_ => _.Name == name);
            }
            return c.ToList();
        }

        public GetAComplexDto GetById(int id)
        {
            var complex = _complexes
                .Where(_ => _.Id == id)
                .Select(_=> new GetAComplexDto 
                {
                    Id = _.Id,
                    Name = _.Name,
                    FilledUnitCount = _.Blocks.SelectMany(_ => _.Units).Count(),
                    RemainingUnitCount = _.UnitCount - _.Blocks.SelectMany(_ => _.Units).Count(),
                    FilledBlocks = _.Blocks.Count()
                })
                .FirstOrDefault();
            return complex;
        }

        public void Update(Complex complex)
        {
            _complexes.Update(complex);
        }
    }
}
