using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace AppConfigurations
{
	public abstract class AppConfiguration
	{
		private const string Delimeter = ":=";

		protected AppConfiguration()
		{
			ConfigInit();
		}

		private void ConfigInit()
		{
			var configFullPath = GetConfigFullPath();
			if (!File.Exists(configFullPath))
				return;

			var settingsDictionary = GetSettingsDictionary(configFullPath);

			var properties = GetType().GetProperties();
			foreach (var propertyInfo in properties)
			{
				var settingAtr = propertyInfo
					.GetCustomAttributes<SettingAttribute>()
					.FirstOrDefault();
				if (settingAtr == null)
					continue;
				var settingName = settingAtr.SettingName;
				if (!settingsDictionary.ContainsKey(settingName))
					continue;
				var value = settingsDictionary[settingName];
				var propertyType = propertyInfo.PropertyType;
				var targetType = IsNullableType(propertyType) ? Nullable.GetUnderlyingType(propertyType) : propertyType;
				try
				{
					var propertyValue = Convert.ChangeType(value, targetType);
					propertyInfo.SetValue(this, propertyValue, null);
				}
				catch
				{
					// ignored
				}
			}
		}

		private static Dictionary<string, string> GetSettingsDictionary(string configFullPath)
		{
			string[] lines;
			try
			{
				lines = File.ReadAllLines(configFullPath);
			}
			catch (Exception e)
			{
				throw new AppConfigurationException($"File '{configFullPath}' read error", e);
			}
			var settings = lines
				.Where(s => !s.StartsWith("#") && s.Contains(Delimeter))
				.Select(s => s.Split(new[] { Delimeter }, StringSplitOptions.None))
				.Where(p => p[0].Trim(' ') != string.Empty);
			var settingsDictionary = new Dictionary<string, string>();
			foreach (var setting in settings)
			{
				var settingName = setting[0].Trim(' ');
				var settingValue = setting[1].Trim(' ');
				if (!settingsDictionary.ContainsKey(settingName))
					settingsDictionary.Add(settingName, settingValue);
			}

			return settingsDictionary;
		}

		private string GetConfigFullPath()
		{
			var configurationAttribute = GetType().GetCustomAttribute<ConfigurationAttribute>();
			return configurationAttribute != null
				? Path.Combine(AppDomain.CurrentDomain.BaseDirectory, configurationAttribute.ConfigPath)
				: null;
		}

		private static bool IsNullableType(Type type)
		{
			return type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>);
		}
	}
}