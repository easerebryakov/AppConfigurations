# AppConfigurations
```
[Configuration("TestsConfigs/Config")]
public class TestConfig : AppConfiguration
{
	[Setting("setting1")]
	public string Setting1 { get; set; }
	
	[Setting("setting2")]
	public string Setting2 { get; set; } = "default";
	
	[Setting("settingBoolTrue")]
	public bool SettingBoolTrue { get; set; }
}
```

Config file content:
```
setting1 := abc
setting2 := 123
settingBoolTrue := true
```
