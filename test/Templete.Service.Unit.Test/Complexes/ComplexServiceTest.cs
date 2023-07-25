
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Templete.Persistanse.EF.Complexes;
using Templete.Persistanse.EF;
using Templete.TestTools.DataBaseConfig.Unit;
using Xunit.Sdk;
using Templete.TestTools.Factories.Complexes;

namespace CMS.Service.Unit.Test.Complexes
{
    public class ComplexServiceTest : BusinessUnitTest
    {
        private ComplexService _sut;

        public ComplexServiceTest()
        {
            _sut = ComplexServiceFactory.Generate(SetupContext);
        }

        [Fact]
        public void Add_add_a_complex_properly()
        {

            var dto = new AddComplexDto
            {
                Name = "Dummy",
                UnitCapacity = 100
            };

            _sut.Define(dto);

            var expected = ReadContext.Set<Complex>().Single();
            expected.Name.Should().Be(dto.Name);
            expected.UnitCapacity.Should().Be(dto.UnitCapacity);
        }
    }
}
