using IDisp.Pattern.Demo;

Console.WriteLine("Hello, World!");

using var proxy = new HttpProxyService(null);

proxy.Get();