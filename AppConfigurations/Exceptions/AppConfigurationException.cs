using System;

namespace AppConfigurations
{
	public class AppConfigurationException : Exception
	{
		public AppConfigurationException(string message, Exception innerException)
			: base(message, innerException)
		{
		}
	}
}