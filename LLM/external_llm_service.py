import requests
from fastapi import FastApi
from pydantic import BaseModel

app = FastApi()

class LLMRequest(BaseModel):
    prompt: str

OPENAI_API_URL = "https://api.openai.com/v1/completions"
API_KEY = ""

@app.post("/external-generate")
async def generate_text_external(request: LLMRequest):
    payload = {
        "model": "gpt-4"
        "prompt": request.prompt,
        "max_tokens": 150
    }

    headers = {"Authorization": f"Bearer {API_KEY}"}

    response = requests.post(OPENAI_API_URL, json=payload, headers=headers)
    return response.json()