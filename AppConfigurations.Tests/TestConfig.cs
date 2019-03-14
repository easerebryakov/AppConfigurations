namespace AppConfigurations.Tests
{
	[Configuration("../../TestsConfigs/Config")]
	public class TestConfig : AppConfiguration
	{
		[Setting("setting1")]
		public string Setting1 { get; set; }

		[Setting("setting2")]
		public string Setting2 { get; set; }

		[Setting("settingBoolTrue")]
		public bool SettingBoolTrue { get; set; }

		[Setting("settingBoolBadFormat")]
		public bool SettingBoolBadFormat { get; set; }

		[Setting("settingWithDefaultAndBadFormat")]
		public bool SettingWithDefaultAndBadFormat { get; set; } = true;

		[Setting("settingRedefinitionValue")]
		public string SettingRedefinitionValue { get; set; } = "default";

		[Setting("settingInt")]
		public int SettingInt { get; set; }

		[Setting("settingIntNullable")]
		public int? SettingIntNullable { get; set; }
	}
}
