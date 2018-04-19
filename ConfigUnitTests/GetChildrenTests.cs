using System;
using System.Linq;
using FluentAssertions;
using Microsoft.Extensions.Configuration;
using Xunit;

namespace ConfigUnitTests
{
    public class GetChildrenTests
    {
        IConfiguration _configuration;
        public GetChildrenTests()
        {
            _configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
        }
        [Fact]
        public void ReadTest()
        {
            var section = _configuration.GetSection("Mapping");
            var sections = section.GetChildren();
            sections.Should().HaveCount(2);
            var array = sections.ToArray();
            array[0].Key.Should().Be("Dia");
            array[0].Value.Should().Be("Shuzhangya");
            array[1].Key.Should().Be("Sys");
            array[1].Value.Should().Be("Shousuoya");

        }
    }
}
