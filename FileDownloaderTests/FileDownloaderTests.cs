using Microsoft.VisualStudio.TestTools.UnitTesting;
using FileDownloader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Threading;
using Moq;
using Moq.Protected;
using System.Net;
using System.IO;

public interface IFileDataSource
{
    FileStream Open(string path,
                    FileMode mode,
                    FileAccess access,
                    FileShare share);
}

public class FakeHttpMessageHandler : HttpMessageHandler
{
    public virtual HttpResponseMessage Send(HttpRequestMessage request)
    {
        throw new NotImplementedException("Now we can setup this method with our mocking framework");
    }

    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
    {
        return Task.FromResult(Send(request));
    }
}
namespace FileDownloader.Tests
{
    [TestClass()]
    public class FileDownloaderTests
    {
        private Mock<FakeHttpMessageHandler> _fakeHttpMessageHandler;
        private HttpClient _httpClient;

        //[TestMethod()]
        public void DownloadFileTest()
        {

            ///////
            //
            ////////
            var handlerMock = new Mock<HttpMessageHandler>();
            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(@"[{ ""id"": 1, ""title"": ""Cool post!""}, { ""id"": 100, ""title"": ""Some title""}]"),
            };

            handlerMock.Protected().Setup<Task<HttpResponseMessage>>(
                  "SendAsync",
                  ItExpr.IsAny<HttpRequestMessage>(),
                  ItExpr.IsAny<CancellationToken>())
               .ReturnsAsync(response);
            
            var httpClient = new HttpClient(handlerMock.Object);
           
            //var TestedClass = new FileDownloader(httpClient);

            try
            {
                Task ts = TestedClass.DownloadFile(" ", @"c:\1\");
                ts.Wait(1500);
            }
            catch(Exception e)
            {
                Assert.Fail();
                
            }
            Assert.Inconclusive();
        }   
    }
}