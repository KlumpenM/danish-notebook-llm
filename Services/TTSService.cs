using danish_notebook_llm.Models;
using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


namespace danish_notebook_llm.Services;
// Integrates with Coqui TTS or parler TTS
public class TTSService
{
	private readonly HttpClient _httpClient;
	private readonly string _ttsApiUrl = "http://tts:9000/synthesize"; // TTS container URL
	
	public TTSService(HttpClient httpClient)
	{
		_httpClient = httpClient;
	}

	public async Task<Byte[]> ConvertTextToSpeechAsync(string text)
	{
		var requestBody = JsonSerializer.Serialize(new { text });

		var content = new StringContent(requestBody, Encodign.UTF8, "application/json");

		var response = await _httpClient.PostAsync(_ttsApiUrl, content);
		if (!response.IsSuccessStatusCode)
		{
            throw new Exception("Failed to convert text to speech");
        }

		return await response.Content.ReadAsByteArrayAsync();
    }
}
