using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace danish_notebook_llm.Hubs;

// Class for handling SignalR for real-time updates
public class ResponseHub : Hub
{
    public async Task SendLLMResponse(string user, string message)
    {
        await Clients.All.SendAsync("ReceiveLLMResponse", user, message);
    }
}
