using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace AppConfigurations.Tests
{
	[Configuration("../../TestsConfigs/Config")]
	public class TestConfig : Configuration
	{

		public string Setting1 { get; }

		public string Setting2 { get; }
	}

	[TestFixture]
	public class Class1
	{
		[Test]
		public void Test()
		{
			var config = new TestConfig();
		}
	}
}
