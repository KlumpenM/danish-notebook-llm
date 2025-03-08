using System;
using Microsoft.AspNetCore.Mvc;
using danish_notebook_llm.Models;
using danish_notebook_llm.Services;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;


namespace danish_notebook_llm.Controllers;
// Handles TTS API requests
[ApiController]
[Route("api/tts")]
public class TTSController
{
	private readonly TTSService _ttsService;

	public TTSController(TTSService ttsService)
	{
		_ttsService = ttsService;
	}

	[HttpPost("generate")]
	public async Task<IActionResult> GenerateSpeech([FromBody] TTSRequest request)
	{
		if (string.IsNullOrWhiteSpace(request.Text))
		{
			return BadRequest("Text is required");
        }

		var audioData = await _ttsService.ConvertTextToSpeechAsync(request.Text);

		return File(audioData, "audio/mpeg", "output.mp3");
	}
}
