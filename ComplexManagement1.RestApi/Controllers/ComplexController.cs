using ComplexManagement1.Services.Complexes;
using ComplexManagement1.Services.Complexes.Contracts;
using ComplexManagement1.Services.Complexes.Contracts.Dto;
using Microsoft.AspNetCore.Mvc;

namespace ComplexManagement1.RestApi.Controllers
{
    [Route("complexes")]
    [ApiController]
    public class ComplexController : Controller
    {
        private readonly ComplexService _complexAppService;

        public ComplexController(ComplexService complexAppService)
        {
            _complexAppService = complexAppService;
        }

        [HttpPost]
        public void Add([FromBody] AddComplexDto dto)
        {
            _complexAppService.Add(dto);
        }

        [HttpGet]
        public List<GetAllComplexesDto> GetAll()
        {
            return _complexAppService.GetAll();
        }

        [HttpPatch]
        [Route("{id}")]
        public void Update([FromRoute] int id , [FromBody] int newUnitCount)
        {
            _complexAppService.Update(id,newUnitCount);
        }

    }


}
