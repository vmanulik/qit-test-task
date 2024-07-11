using Mapster;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using Qit.Api.Models;
using Qit.Core.Abstractions;
using Qit.Core.Models;

namespace Qit.Api.Controllers
{
    [ApiController]
    [Route("openai")]
    public class OpenAiController(IOpenAiService openAiService,
                                  ILogger<OpenAiController> logger,
                                  IMapper mapper) : ControllerBase
    {
        [HttpPost("popular-attributes")]
        public async Task<ActionResult<IEnumerable<CategoryAttributesDto>>> Get(IEnumerable<Category> request)
        {
            if (request == null)
            {
                return BadRequest();
            }

            try
            {
                var categoryAttributes = request.Adapt<IEnumerable<Category>>();

                IEnumerable<CategoryAttributes> result = await openAiService.SendRequest(categoryAttributes);

                return Ok(mapper.Map<CategoryAttributesDto>(result));

            }
            catch (Exception e)
            {
                logger.LogError(e, e.Message);

                return this.BadRequest(e.Message);
            }
        }
    }
}
