namespace Mono.Tests
{
	[TestClass]
	public class SampleTest
	{
		[TestMethod]
		public void SampleTestMethod()
		{
			Assert.IsTrue(true);
		}

		[TestMethod]
		public void OtherMethod()
		{
			Assert.IsFalse(false);
		}
	}
}