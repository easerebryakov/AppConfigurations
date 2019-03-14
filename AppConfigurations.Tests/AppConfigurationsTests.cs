using NUnit.Framework;

namespace AppConfigurations.Tests
{
	[TestFixture]
	public class AppConfigurationsTests
	{
		private readonly TestConfig config = new TestConfig();

		[Test]
		public void SimpleStringSettingTest()
		{
			Assert.AreEqual("123", config.Setting2);
		}

		[Test]
		public void RepeatedSetting_ShouldBe_FirstSetting()
		{
			Assert.AreEqual("abc", config.Setting1);
		}

		[Test]
		public void SettingBool_ValueTrue_ShouldBe_True()
		{
			Assert.IsTrue(config.SettingBoolTrue);
		}

		[Test]
		public void SettingBool_ValueBadFormat_ShouldBe_Default()
		{
			Assert.IsFalse(config.SettingBoolBadFormat);
		}

		[Test]
		public void SettingBool_DefaultTrue_BadFormat_ShouldBe_True()
		{
			Assert.IsTrue(config.SettingWithDefaultAndBadFormat);
		}

		[Test]
		public void Setting_RedefinitionValue()
		{
			Assert.AreEqual("newValue", config.SettingRedefinitionValue);
		}

		[Test]
		public void SimpleIntSettingTest()
		{
			Assert.AreEqual(123456, config.SettingInt);
		}

		[Test]
		public void SettingInt_Nullable()
		{
			Assert.AreEqual(111, config.SettingIntNullable);
		}
	}
}