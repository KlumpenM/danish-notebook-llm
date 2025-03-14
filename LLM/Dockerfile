# Use Python base image
FROM python:3.12-slim as base

# Set working directory
WORKDIR /app

# Install system dependencies
RUN apt-get update && apt-get install -y \
    build-essential \
    && rm -rf /var/lib/apt/lists/*

# Copy requirements files
COPY requirements.txt requirements-dev.txt ./

# Development stage with tests
FROM base as test
RUN pip install --no-cache-dir -r requirements.txt -r requirements-dev.txt
COPY . .
RUN pytest tests/

# Production stage
FROM base as prod
RUN pip install --no-cache-dir -r requirements.txt

# Copy the rest of the application
COPY . .

# Expose the port
EXPOSE 8000

# Start the LLM server
CMD ["python", "server.py"] 