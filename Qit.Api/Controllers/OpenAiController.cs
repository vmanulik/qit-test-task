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
        public async Task<ActionResult<CategoryAttributesResponse>> Get(CategoryAttributesRequest request)
        {
            if (request == null)
            {
                return BadRequest();
            }

            try
            {
                var categoryAttributes = request.Categories.Adapt<IEnumerable<Category>>();

                IEnumerable<CategoryAttributes> result = await openAiService.SendRequest(categoryAttributes);

                return Ok(mapper.Map<CategoryAttributesResponse>(result));

            }
            catch (Exception e)
            {
                logger.LogError(e, e.Message);

                return this.BadRequest(e.Message);
            }
        }
    }
}
