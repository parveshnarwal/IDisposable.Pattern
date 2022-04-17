using IDisp.Pattern.Demo;

Console.WriteLine("Hello, World!");

//using key word will automatically call the Dispose method
using var proxy = new HttpProxyService(null);

proxy.Get();