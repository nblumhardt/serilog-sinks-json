using System;
using Serilog;

namespace Example
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.JsonConsole()
                .CreateLogger();

            Log.Information("Hello, world from {Username}!", Environment.GetEnvironmentVariable("USERNAME"));

            Log.CloseAndFlush();
        }
    }
}
