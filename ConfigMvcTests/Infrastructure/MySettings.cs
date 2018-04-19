using System.Collections.Generic;

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