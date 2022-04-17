using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace IDisp.Pattern.Demo;

public class HttpProxyService : IDisposable
{


    private readonly HttpClient httpClient;
    private bool disposed;

    public HttpProxyService(IHttpClientFactory httpClientFactory)
    {
        httpClient = httpClientFactory.CreateClient();
    }

    ~HttpProxyService()
    {
        Dispose(false);
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposed)
        {
            return;
        }

        if (disposing)
        {
            // Dispose managed objects
            httpClient.Dispose();
        }
        
        // Dispose unmanaged objects


        //Set disposed to true
        disposed = true;
    }

    public void Get()
    {
        var response = httpClient.GetAsync("");
    }

    public void Post(string request)
    {
        var response = httpClient.PostAsync("", new StringContent(request));
    }
}
