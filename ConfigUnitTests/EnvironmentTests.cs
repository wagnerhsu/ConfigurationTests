using System;
using System.Linq;
using FluentAssertions;
using Microsoft.Extensions.Configuration;
using Xunit;

namespace ConfigUnitTests
{
    public class EnvironmentTests
    {
        IConfiguration _configuration;
        public EnvironmentTests()
        {
            _configuration = new ConfigurationBuilder()
                .AddEnvironmentVariables()
                .Build();
        }
        [Fact]
        public void ReadTest()
        {
            var section = _configuration.GetSection("Path");
            var values = section.GetChildren();
            foreach (var env in values)
            {
                Console.WriteLine($"{env.Key}:{ env.Value}");
            }
            values.Should().NotBeNull();
        }
    }
}
