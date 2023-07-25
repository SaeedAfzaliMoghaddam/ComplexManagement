using Microsoft.AspNetCore.Mvc;

namespace Templete.RestApi.Controllers
{
    [Route("complexes")]
    [ApiController]
    public class ComplexesController : Controller
    {
        private readonly ComplexService _complexService;

        public ComplexesController(ComplexService complexService)
        {
            _complexService = complexService;
        }

        [HttpPost]
        public void Add([FromBody] AddComplexDto dto) 
        {
            _complexService.Define(dto);
        }

    }
}
