using System;

namespace AppConfigurations
{
	public class ConfigurationAttribute : Attribute
	{
		public string ConfigPath { get; }
		
		/// <summary>
		/// Set the relative path to config file
		/// </summary>
		/// <param name="configPath"></param>
		public ConfigurationAttribute(string configPath)
		{
			ConfigPath = configPath;
		}
	}
}
