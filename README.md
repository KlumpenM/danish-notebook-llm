# Description
This is a hobby project, of trying to recreate/reverse-engineer googles "Notebook LLM", where there is a feature for creating a podcast from an uploaded PDF, since they are only able to do it in English, then I'm trying to do it, where danish is available.

# Tech Stack
The following technologies that I'm using
- Huggingface (For Cloud access to LLM)
- Corqui-TTS (TTS)
- Blazor (Frontend)
- Docker
- FastAPI (Python)
- PostgreSQL (For historical handling)

# Overview of folder structure
This is the planned structure of the project
```
/PodcastAI-Project
│── /Backend              # .NET 8 Backend (ASP.NET Core API)
│   │── /Controllers
│   │   ├── LLMController.cs    # Handles LLM API requests
│   │   ├── TTSController.cs    # Handles TTS processing
│   │   ├── PodcastController.cs # (Future) Manage podcast storage
│   │
│   │── /Services
│   │   ├── LLMService.cs       # Calls Hugging Face LLM (local/external)
│   │   ├── TTSService.cs       # Integrates with custom-trained TTS
│   │
│   │── /Hubs
│   │   ├── ResponseHub.cs      # SignalR for real-time updates
│   │
│   │── /Models
│   │   ├── LLMRequest.cs       # Request model for LLM
│   │   ├── LLMResponse.cs      # Response model for LLM
│   │   ├── TTSRequest.cs       # Request model for TTS
│   │
│   │── /Repositories           # (Future) Handles database storage
│   │── Program.cs              # ASP.NET Core startup
│   │── appsettings.json        # Config file
│   │── Dockerfile              # Backend container setup
│
│── /Frontend            # Blazor Server Frontend
│   │── /Pages
│   │   ├── Index.razor          # Main UI page
│   │   ├── LLMResults.razor     # Shows AI-generated text
│   │   ├── AudioPlayer.razor    # Plays TTS audio output
│   │
│   │── /Components
│   │   ├── TextInput.razor      # Text input component
│   │   ├── ResponseDisplay.razor # Shows LLM response
│   │   ├── AudioPlayer.razor    # Audio playback
│   │
│   │── /Services
│   │   ├── ApiService.cs        # Calls .NET backend
│   │   ├── WebSocketService.cs  # Handles SignalR real-time updates
│   │
│   │── App.razor                # Entry point
│   │── Program.cs               # Blazor startup
│   │── wwwroot                  # Static assets
│
│── /LLM                # Hugging Face LLM API (FastAPI)
│   │── llm_api.py             # FastAPI service for local model
│   │── external_llm_service.py # Calls external APIs (e.g., OpenAI)
│   │── requirements.txt        # Python dependencies
│   │── Dockerfile              # LLM container setup
│
│── /TTS                # Custom-trained TTS (FastAPI)
│   │── custom_tts.py          # FastAPI service for TTS
│   │── requirements.txt       # Python dependencies
│   │── Dockerfile             # TTS container setup
│   │── /models
│   │   ├── custom_tts.pth     # Trained TTS model file
│
│── /Database           # (Future) Database setup (PostgreSQL)
│   │── init.sql               # DB initialization script
│   │── docker-compose.yml      # DB container setup
│
│── /docker-compose.yml # Defines and connects all services
│── /README.md          # Documentation

```
