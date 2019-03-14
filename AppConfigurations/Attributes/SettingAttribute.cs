using System;

namespace AppConfigurations
{
	public class SettingAttribute : Attribute
	{
		public string SettingName { get; }

		/// <summary>
		/// Set the name of the setting
		/// </summary>
		/// <param name="settingName"></param>
		public SettingAttribute(string settingName)
		{
			SettingName = settingName;
		}
	}
}