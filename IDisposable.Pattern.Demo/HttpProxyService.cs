namespace IDisp.Pattern.Demo;

public class HttpProxyService : IDisposable
{


    private readonly HttpClient httpClient;
    private bool disposed;

    public HttpProxyService(IHttpClientFactory httpClientFactory)
    {
        httpClient = httpClientFactory.CreateClient();
    }

    public void Get()
    {
        var response = httpClient.GetAsync("");
    }

    public void Post(string request)
    {
        var response = httpClient.PostAsync("", new StringContent(request));
    }


    // ~HttpProxyService will be called by Garbage collector
    // after the run is completed
    // hence we are passing false so that we don't repeat cleaning process for managed resource
    ~HttpProxyService()
    {
        Dispose(false);
    }


    //This will be called when we create objects of this class with "using" keyword
    //Or we can call it explicitly like any other normal method
    public void Dispose()
    {
        Dispose(true);

        // Telling Garbage collector to NOT call finalizer because cleaning of managed and unmanaged code is already done
        GC.SuppressFinalize(this);
    }


    protected virtual void Dispose(bool disposing)
    {
        if (disposed)
        {
            //return without doing anything because cleaning is done already
            return;
        }

        //Start cleaning process here

        if (disposing)
        {
            // Dispose managed objects
            httpClient.Dispose();
        }

        // Dispose unmanaged objects


        //Set disposed to true
        disposed = true;
    }
}
