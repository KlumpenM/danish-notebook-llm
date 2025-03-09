using System.Net;
using System.Text;
using danish_notebook_llm.Services;
using Moq;
using Moq.Protected;
using Xunit;

namespace Backend.Tests.Services;

public class TTSServiceTests
{
    [Fact]
    public async Task ConvertTextToSpeechAsync_SuccessfulRequest_ReturnsByteArray()
    {
        // Arrange
        var expectedBytes = new byte[] { 1, 2, 3, 4 };
        var mockHttpMessageHandler = new Mock<HttpMessageHandler>();
        mockHttpMessageHandler.Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>()
            )
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new ByteArrayContent(expectedBytes)
            });

        var client = new HttpClient(mockHttpMessageHandler.Object);
        var service = new TTSService(client);

        // Act
        var result = await service.ConvertTextToSpeechAsync("Test text");

        // Assert
        Assert.Equal(expectedBytes, result);
        mockHttpMessageHandler.Protected().Verify(
            "SendAsync",
            Times.Once(),
            ItExpr.Is<HttpRequestMessage>(req =>
                req.Method == HttpMethod.Post &&
                req.RequestUri.ToString() == "http://tts_local:9000/synthesize"),
            ItExpr.IsAny<CancellationToken>()
        );
    }

    [Fact]
    public async Task ConvertTextToSpeechAsync_FailedRequest_ThrowsException()
    {
        // Arrange
        var mockHttpMessageHandler = new Mock<HttpMessageHandler>();
        mockHttpMessageHandler.Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>()
            )
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.InternalServerError
            });

        var client = new HttpClient(mockHttpMessageHandler.Object);
        var service = new TTSService(client);

        // Act & Assert
        await Assert.ThrowsAsync<Exception>(
            () => service.ConvertTextToSpeechAsync("Test text")
        );
    }
} 