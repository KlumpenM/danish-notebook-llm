from fastapi import fastapi
from pydantic import BaseModel
from transformers import pipeline

# Load a Hugging Face model locally
model_name = "mistralai/Mistral-7B-Instruct-v0.1"
llm_pipeline = pipeline("text-generation", model=model_name, device_map="auto")

# FastApi app
app = fastapi()

class LLMRequest(BaseModel):
    prompt: str


@app.post("/generate")
async def generate_text(request: LLMRequest):
    response = llm_pipeline(request.prompt, max_length=200, do_sample=True)
    return {"generated_text": response[0]["generated_text"]}