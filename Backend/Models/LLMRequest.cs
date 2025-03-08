using System;
using System.Security.Cryptography.X509Certificates;

namespace danish_notebook_llm.Models;
// Request model for LLM
public class LLMRequest
{
	public string InputText { get; set; }
}
