using System;
using System.Linq;
using FluentAssertions;
using Microsoft.Extensions.Configuration;
using Xunit;

namespace ConfigUnitTests
{
    public class GetArrayTests
    {
        IConfiguration _configuration;
        public GetArrayTests()
        {
            _configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
        }
        [Fact]
        public void ReadTest()
        {
            var section = _configuration.GetSection("Colors");
            var values = section.GetChildren();
            values.Should().HaveCount(3);
            var array = values.ToArray();
            array[0].Key.Should().Be("0");
            array[0].Value.Should().Be("Red");
        }
    }
}
