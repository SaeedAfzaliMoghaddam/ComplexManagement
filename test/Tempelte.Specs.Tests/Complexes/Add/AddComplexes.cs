using FluentAssertions;
using System.Linq;
using Templete.Persistanse.EF;
using Templete.Persistanse.EF.Complexes;
using Templete.TestTools.DataBaseConfig.Integration;
using Templete.TestTools.Factories.Complexes;
using Xunit;

namespace Tempelte.Specs.Tests.Complexes.Add
{
    [Scenario("تعریف مجتمع")]
    public class AddComplexes : BusinessIntegrationTest
    {
        private ComplexAppService _sut;

        public AddComplexes()
        {
            _sut = ComplexServiceFactory.Generate(SetupContext);
        }

        [Given("فهرست مجتمع ها خالی است")]
        public void Given()
        {

        }

        [When("یک مجتمع با نام فپکو و تعداد واحد 400 را ثبت میکنم")]
        public void When()
        {
            
            var dto = new AddComplexDto
            {
                Name= "فپکو",
                UnitCapacity= 400
            };
            _sut.Define(dto);
        }

        [Then("یک مجتمع با نام فپکو " +
            "و تعداد واحد 400 " +
            "باید در فهرست مجتمع ها وجود داشته باشد")]
        public void Then() 
        {
            var expected = ReadContext.Set<Complex>().Single();
            expected.Name.Should().Be("فپکو");
            expected.UnitCapacity.Should().Be(400);
        }

        [Fact]
        public void Run()
        {
            Runner.RunScenario
                (
                _=> Given(),
                _=> When(),
                _=> Then()
                );
        }

    }
}


