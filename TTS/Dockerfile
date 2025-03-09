# Use the official Coqui TTS image
FROM coqui-ai/tts

# Set working directory
WORKDIR /app

# Copy any custom models or configurations
COPY . .

# Expose the port
EXPOSE 9000

# Start the TTS server
CMD ["tts-server", "--model_path", "/models/da_model.pth", "--port", "9000"] 