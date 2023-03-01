using Xunit;

namespace K4os.Template.Test
{
	public class UnitTest1
	{
		private readonly Class1 _sut = new();

		[Fact]
		public void Test1()
		{
			Assert.Equal("42", _sut.IntToString(42));
		}
	}
}
