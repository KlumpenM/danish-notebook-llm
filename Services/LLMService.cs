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
	private readonly string _llmApiUrl = "http://llm:8000/generate"; // LLM container URL

	public LLMService(HttpClient httpClient)
	{
			_httpClient = httpClient; 
    }

	public async Task<LLMResponse> ProcessTextAsync(string input)
	{
		var requestBody = JsonSerializer.Serialize(new { input });
		var content = new StringContent(requestBody, Encoding.UTF8, "application/json");

		var response = await _httpClient.PostAsync(_llmApiUrl, content);
		var responseString = await response.Content.ReadAsStringAsync();

		return new LLMResponse { ProcessedText = responseString };
    }	
