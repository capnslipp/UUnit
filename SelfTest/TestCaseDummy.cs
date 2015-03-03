//using UnityEngine;



internal class TestCaseDummy : UUnitTestCase
{
	public bool wasRun;
	public bool wasSetUp;
	public string log;
	
	
	[UUnitTest]
	void TestMethod()
	{
		this.wasRun = true;
	}
	
	override protected void SetUp()
	{
		this.wasRun = false;
		this.wasSetUp = true;
		this.log = "setUp ";
	}
	
	[UUnitTest]
	void TestFail()
	{
		UUnitAssert.True(false, "Expected Fail Result");
	}
}
