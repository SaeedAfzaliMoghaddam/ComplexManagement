using ComplexManagement1.Entities;
using ComplexManagement1.Persistance.EF;
using ComplexManagement1.Persistance.EF.Blocks;
using ComplexManagement1.Services.Blocks.Exceptions;
using ComplexManagement1.Services.Unit.Test.DataBaseConfig;
using ComplexManagement1.Services.Unit.Test.DataBaseConfig.Unit;
using ComplexManagement1.Services.Units;
using ComplexManagement1.Services.Units.Contracts.Dto;
using FluentAssertions;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexManagement1.Services.Unit.Test.Units
{
    public class UnitServiceTest : BusinessUnitTest
    {
        [Theory]
        [InlineData(ResidenseType.tenent)]
        [InlineData(ResidenseType.empty)]
        [InlineData(ResidenseType.owner)]
        public void Add_add_a_unit_properly(ResidenseType residenseType)
        {
            var repository = new EFUnitRepository(SetupContext);
            var unitOfWork = new EFUnitOfWork(SetupContext);
            var blockRepository = new EFBlockRepository(SetupContext);
            var sut = new UnitAppService(repository, unitOfWork, blockRepository);
            var complex = new Complex
            {
                Name = "dummy",
                UnitCount = 10,
            };
            var block = new Block
            {
                Name = "dummy",
                UnitCount = 4,
                Complex = complex
            };
            DbContext.Save(block);
            var dto = new AddUnitDto
            {
                Name = "Dummy",
                ResidenseType = residenseType,
                BlockId = block.Id
            };

            sut.Add(dto);

            var expected = ReadContext.Set<Entities.Unit>();
            expected.Should().HaveCount(1);
            expected.First().Name.Should().Be(dto.Name);
            expected.First().ResidenseType.Should().Be(residenseType);

        }

        [Fact]
        public void Add_throws_new_exception_when_unitName_is_Dublicate_in_a_block()
        {
            var repository = new EFUnitRepository(SetupContext);
            var unitOfWork = new EFUnitOfWork(SetupContext);
            var blockRepository = new EFBlockRepository(SetupContext);
            var sut = new UnitAppService(repository, unitOfWork, blockRepository);
            var complex = new Complex
            {
                Name = "dummy",
                UnitCount = 10,
            };
            var block = new Block
            {
                Name = "dummy",
                UnitCount = 10,
                Complex = complex

            };
            DbContext.Save(block);
            var unit = new Entities.Unit
            {
                Name = "dummy",
                Block = block,
            };
            DbContext.Save(unit);
            var Dto = new AddUnitDto
            {
                Name = "dummy",
                BlockId = block.Id,
            };

            var excepted = () => sut.Add(Dto);

            excepted.Should().ThrowExactly<DublicateUnitNameException>();
        }

        [Fact]
        public void Add_throws_new_exception_when_BlockId_does_not_Found()
        {
            var repository = new EFUnitRepository(SetupContext);
            var unitOfWork = new EFUnitOfWork(SetupContext);
            var blockRepository = new EFBlockRepository(SetupContext);
            var sut = new UnitAppService(repository, unitOfWork, blockRepository);
            var dto = new AddUnitDto
            {
                Name = "dummy",
                BlockId = 1,
            };

            var excepted = () => sut.Add(dto);

            excepted.Should().ThrowExactly<BlockNotFoundException>();
        }

        [Fact]
        public void Add_throws_new_exception_when_unitCount_is_not_valid()
        {
            var repository = new EFUnitRepository(SetupContext);
            var unitOfWork = new EFUnitOfWork(SetupContext);
            var blockRepository = new EFBlockRepository(SetupContext);
            var sut = new UnitAppService(repository, unitOfWork, blockRepository);
            var complex = new Complex
            {
                Name= "dummys",
            };
            var block = new Block
            {
                Name = "dummyB",
                UnitCount = 0,
                Complex = complex
            };
            DbContext.Save(block);
            var dto = new AddUnitDto
            {
                Name= "dummyU",
                BlockId = block.Id,
            };

            var excepted = () => sut.Add(dto);

            excepted.Should().ThrowExactly<InvalidUnitCountException>();
        }

    }
}
