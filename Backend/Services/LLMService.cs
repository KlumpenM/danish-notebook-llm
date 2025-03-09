using danish_notebook_llm.Models;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace danish_notebook_llm.Services;

// Calls and manages the LLM models
public class LLMService
{
	private readonly HttpClient _httpClient;
	private readonly string _LocalLlmUrl = "http://llm_local:8000/generate"; // LLM container URL
	private readonly string _externalLlmUrl = "http://llm_external:8100/external-generate"

	public LLMService(HttpClient httpClient)
	{
		_httpClient = httpClient;
	}

	public async Task<LLMResponse> ProcessTextAsync(string input, bool useExternal = False)
	{
		string url = useExternal ? _externalLlmUrl : _LocalLlmUrl;
		var requestBody = JsonSerializer.Serialize(new { input });
		var content = new StringContent(requestBody, Encoding.UTF8, "application/json");

		var response = await _httpClient.PostAsync(_llmApiUrl, content);
		return await response.Content.ReadAsStringAsync();

	}
}
