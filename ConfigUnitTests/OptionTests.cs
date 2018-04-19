using System.Collections.Generic;
using System.IO;
using FluentAssertions;
using Microsoft.Extensions.Configuration;
using Xunit;

namespace ConfigUnitTests
{
    public class OptionTests
    {
        IConfiguration _configuration;
        public OptionTests()
        {
            _configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();
        }
        [Fact]
        public void BindStrongTypeObject()
        {
            // 一定要先将MySettings创建出来，再绑定
            // 我们没有必须再为实例的各个属性如Dict显示创建，
            // Bind会完成这些
            MySettings mySettings = new MySettings();
            _configuration.Bind("MySettings", mySettings);
            mySettings.IntSetting.Should().Be(23);
            mySettings.Dict.Should().HaveCount(2);
        }
    }
    public class MySettings
    {
        public string StringSetting { get; set; }
        public int IntSetting { get; set; }
        public Dictionary<string, InnerClass> Dict { get; set; }
        public List<string> ListOfValues { get; set; }
        public MyEnum AnEnum { get; set; }
    }

    public class InnerClass
    {
        public string Name { get; set; }
        public bool IsEnabled { get; set; } = true;
    }

    public enum MyEnum
    {
        None = 0,
        Lots = 1
    }
}