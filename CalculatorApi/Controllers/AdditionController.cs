using System.Linq;
using CalculatorApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace CalculatorApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdditionController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post(MultiInputModel input)
        {
            IActionResult result = null;

            if (input == null || input.Inputs.Count == 0)
            {
                result = new BadRequestResult();
            }
            else
            {
                var sum = input.Inputs.Sum(_ => _);
                var resultModel = new ResultModel {Result = sum};

                result = new OkObjectResult(resultModel);
            }

            return result;
        }
    }
}
