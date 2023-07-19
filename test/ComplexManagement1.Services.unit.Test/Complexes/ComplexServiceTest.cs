using ComplexManagement1.Entities;
using ComplexManagement1.Persistance.EF;
using ComplexManagement1.Persistance.EF.Complexes;
using ComplexManagement1.Services.Complexes;
using ComplexManagement1.Services.Complexes.Contracts.Dto;
using ComplexManagement1.Services.Complexes.Exceptions;
using FluentAssertions;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Utilities;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TaavArchitecture.TestTools.Infrastructure.DataBaseConfig;
using TaavArchitecture.TestTools.Infrastructure.DataBaseConfig.Unit;

namespace ComplexManagement1.Services.Unit.Test.Complexes
{
    public class ComplexServiceTest : BusinessUnitTest
    {
        [Fact]
        public void Add_add_a_complex_properly()
        {
            var repository = new EFComplexRepository(SetupContext);
            var unitOfWork = new EFUnitOfWork(SetupContext);
            var sut = new ComplexAppService(repository, unitOfWork);
            var dto = new AddComplexDto
            {
                Name = "dummy",
                UnitCount = 10,
            };

            sut.Add(dto);

            var expected = ReadContext.Set<Complex>().Single();
            expected.Name.Should().Be(dto.Name);
            expected.UnitCount.Should().Be(dto.UnitCount);
        }

        [Fact]
        public void Get_get_all_complexes_properly()
        {
            var repository = new EFComplexRepository(SetupContext);
            var unitOfWork = new EFUnitOfWork(SetupContext);
            var sut = new ComplexAppService(repository, unitOfWork);
            var complex = new Complex
            {
                Name = "dummy",
                UnitCount = 10,

            };
            DbContext.Save(complex);

            var expected = sut.GetAll().ToList();

            expected.Should().HaveCount(1);
            expected.First().Name.Should().Be(complex.Name);
            expected.First().UnitCount.Should().Be(complex.UnitCount);
            expected.First().Id.Should().Be(complex.Id);

        }

        [Fact]
        public void Update_update_unitCount_of_a_complex_properly()
        {
            var repository = new EFComplexRepository(SetupContext);
            var unitOfWork = new EFUnitOfWork(SetupContext);
            var sut = new ComplexAppService(repository, unitOfWork);
            var complex = new Complex
            {
                Name = "dummy",
                UnitCount = 10,

            };
            DbContext.Save(complex);
            var newUnitCount = -1;

            sut.Update(complex.Id, newUnitCount);

            var expected = ReadContext.Set<Complex>().ToList();
            expected.Should().HaveCount(1);
            expected.First().UnitCount.Should().Be(newUnitCount);
        }

        [Fact]
        public void Update_throw_new_exception_when_complex_not_found()
        {
            var repository = new EFComplexRepository(SetupContext);
            var unitOfWork = new EFUnitOfWork(SetupContext);
            var sut = new ComplexAppService(repository, unitOfWork);
            var complex = new Complex
            {
                Name = "dummy",
                UnitCount = 10,

            };
            DbContext.Save(complex);
            var invalidId = -1;

            var expected = () => sut.Update(invalidId, complex.UnitCount);

            expected.Should().ThrowExactly<ComplexNotFoundException>();

        }

        [Fact]
        public void Get_get_all_complexes_with_unit_details_properly()
        {
            var repository = new EFComplexRepository(SetupContext);
            var unitOfWork = new EFUnitOfWork(SetupContext);
            var sut = new ComplexAppService(repository, unitOfWork);
            var complex = new Complex
            {
                Name = "dummy",
                UnitCount = 100,
            };            
            var block = new Block
            {
                
                Name = "dummy",
                UnitCount = 10,
                Complex = complex,
            };
            var unit = new Entities.Unit
            {                
                Block = block,
                Name = "dummy",
                ResidenseType = ResidenseType.empty
            };
            DbContext.Save(unit);

            var result = sut.GetAllWithUnitsDetails();

            result.Should().HaveCount(1);
            result.First().Id.Should().Be(complex.Id);
            result.First().Name.Should().Be(complex.Name);
            result.First().RemainingUnitCount.Should().Be(complex.UnitCount - block.Units.Count());
            result.First().FilledUnitCount.Should().Be(block.Units.Count());

        }

        [Fact]
        public void Get_get_all_complexes_with_unit_details_filtered_by_name_properly()
        {
            var repository = new EFComplexRepository(SetupContext);
            var unitOfWork = new EFUnitOfWork(SetupContext);
            var sut = new ComplexAppService(repository, unitOfWork);
            var complex = new Complex
            {
                Name = "dummy",
                UnitCount = 100,
            };
             DbContext.Save(complex);
            var complex2 = new Complex
            {
                Name = "dummy2",
                UnitCount = 100,
            };
            DbContext.Save(complex2);
            var block = new Block
            {

                Name = "dummy",
                UnitCount = 10,
                Complex = complex,
            };
            var unit = new Entities.Unit
            {
                Block = block,
                Name = "dummy",
                ResidenseType = ResidenseType.empty
            };
            DbContext.Save(unit);

            var result = sut.GetAllWithUnitsDetails(complex.Name);

            
            result.Should().HaveCount(1);
            result.First().Id.Should().Be(complex.Id);
            result.First().Name.Should().Be(complex.Name);
            result.First().RemainingUnitCount.Should().Be(complex.UnitCount - block.Units.Count());
            result.First().FilledUnitCount.Should().Be(block.Units.Count());

        }

        [Fact]
        public void Get_get_a_complex_by_id_properly()
        {
            var repository = new EFComplexRepository(SetupContext);
            var unitOfWork = new EFUnitOfWork(SetupContext);
            var sut = new ComplexAppService(repository, unitOfWork);
            var complex = new Complex
            {
                Name= "dummy",
            };
            DbContext.Save(complex);

            var expected = sut.GetById(complex.Id);

            expected.Id.Should().Be(complex.Id);
            expected.Name.Should().Be(complex.Name);

        }

    }
}
