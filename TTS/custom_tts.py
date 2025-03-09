from fastapi import FastApi
from pydantic import BaseModel
import torch
from TTS.api import TTS

# Load the trained model
MODEL_PATH = ""
tts_model = TTS(MODEL_PATH).to(torch.device("cpu"))

app = FastApi()

class TTSRequest(BaseModel):
    text: str

@app.post("/synthesize")
async def synthesize_speech(request: TTSRequest):
    output_path = "output.wav"
    tts_model.tts_to_file(text=request.text, file_path=output_path)
    return {"message": "Speech synthesized", "file": output_path}