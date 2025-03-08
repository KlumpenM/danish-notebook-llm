using Microsoft.AspNetCore.Mvc;
using danish_notebook_llm.Models;
using danish_notebook_llm.Services;
using System.Threading.Tasks;

namespace danish_notebook_llm.Controllers;
// Class for handling LLM API requests
[ApiController]
[Route("api/llm")]
public class LLMController : ControllerBase
{
	private readonly LLMService _llmService;

	public LLMController (LLMService llmService)
	{
		_llmService = llmService;
	}

	[HttpPost("process")]
	public async Task<IActionResult> ProcessText([FromBody] LLMRequest request)
	{
		if (string.IsNullOrWhiteSpace(request.InputText))
		{
			return BadRequest("Input text is required");
        }

		var result = await _llmService.ProcessTextAsync(request.InputText);
		return Ok(result);
	}
}
