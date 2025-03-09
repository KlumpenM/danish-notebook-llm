import pytest
from unittest.mock import Mock, patch
from server import app
from fastapi.testclient import TestClient

client = TestClient(app)

def test_health_check():
    response = client.get("/health")
    assert response.status_code == 200
    assert response.json() == {"status": "healthy"}

@pytest.mark.asyncio
@patch('server.llm_model')  # Assuming you have an LLM model instance
async def test_generate_text(mock_llm):
    # Mock the LLM response
    mock_llm.generate.return_value = "Generated response"
    
    response = client.post(
        "/generate",
        json={"prompt": "Test prompt", "max_length": 100}
    )
    
    assert response.status_code == 200
    assert "text" in response.json()
    assert response.json()["text"] == "Generated response"
    
    # Verify the mock was called with correct parameters
    mock_llm.generate.assert_called_once_with(
        "Test prompt",
        max_length=100
    )

@pytest.mark.asyncio
async def test_generate_text_invalid_input():
    response = client.post(
        "/generate",
        json={"prompt": "", "max_length": -1}
    )
    
    assert response.status_code == 400
    assert "error" in response.json() 