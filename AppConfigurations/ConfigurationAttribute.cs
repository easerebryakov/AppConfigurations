using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AppConfigurations
{
	public class Configuration
	{
		private const string Delimeter = ":=";

		public Configuration()
		{
			ConfigInit();
		}

		private void ConfigInit()
		{
			var configFullPath = GetConfigFullPath();
			if (!File.Exists(configFullPath))
				return;
			var settingsDictionary = File.ReadAllLines(configFullPath)
				.Where(s => !s.StartsWith("#") && s.Contains(Delimeter))
				.Select(s => s.Split(new []{Delimeter}, StringSplitOptions.None))
				.Where(p => p[0].Trim(' ') != string.Empty)
				.ToDictionary(p => p[0].Trim(' '), p => p[1].Trim(' '));

			var properties = GetType().GetProperties();
		}
		
		private string GetConfigFullPath()
		{
			var configurationAttribute = GetType().GetCustomAttribute<ConfigurationAttribute>();
			return configurationAttribute != null
				? Path.Combine(AppDomain.CurrentDomain.BaseDirectory, configurationAttribute.ConfigPath)
				: null;
		}
	}

	public class SettingAttribute : Attribute
	{
		public string SettingName { get; }

		public SettingAttribute(string settingName)
		{
			SettingName = settingName;
		}
	}

	public class ConfigurationAttribute : Attribute
	{
		public string ConfigPath { get; }
		
		/// <summary>
		/// </summary>
		/// <param name="configPath">Relative config path</param>
		public ConfigurationAttribute(string configPath)
		{
			ConfigPath = configPath;
		}
	}
}
