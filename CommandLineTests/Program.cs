using System;
using System.Linq;
using Microsoft.Extensions.Configuration;

namespace CommandLineTests
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .AddCommandLine(args)
                .Build();
            var children = config.GetChildren().ToArray();
            foreach (var child in children)
                Console.WriteLine($"{child.Key}:{child.Value}");
            foreach(var c in config.AsEnumerable()) {
                 Console.WriteLine($"{c.Key,-15}:{c.Value}");
            }
        }
    }
}
