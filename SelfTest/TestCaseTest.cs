//using UnityEngine;



internal class TestCaseTest : UUnitTestCase
{
	[UUnitTest]
	void TestRunning()
	{
		TestCaseDummy local = (TestCaseDummy)(this.local = new TestCaseDummy { Testx = "TestMethod" });
		UUnitAssert.False(local.wasRun, " not wasRun");
		local.Run(null);
		UUnitAssert.True(local.wasRun, "wasRun");
	}
	
	[UUnitTest]
	void TestSetUp()
	{
		TestCaseDummy local = (TestCaseDummy)(this.local = new TestCaseDummy { Testx = "TestMethod" });
		local.Run(null);
		UUnitAssert.True(local.wasSetUp, "wasSetUp");
		UUnitAssert.EqualString(local.log, "setUp ", "setup");
	}
	
	[UUnitTest]
	void TestResult()
	{
		TestCaseDummy local = (TestCaseDummy)(this.local = new TestCaseDummy { Testx = "TestMethod" });
		UUnitTestResult result = local.Run(null);
		UUnitAssert.EqualString("1 run, 0 failed", result.Summary(), "testResult");
	}
	
	[UUnitTest]
	void TestFailure()
	{
		TestCaseDummy local = (TestCaseDummy)(this.local = new TestCaseDummy { Testx = "TestFail" });
		UUnitTestResult result = local.Run(null);
		UUnitAssert.EqualString("1 run, 1 failed", result.Summary(), "Failure");
	}

	[UUnitTest]
	void TestTestSuiteAdd()
	{
		UUnitTestSuite suite = new UUnitTestSuite();
		suite.Add(new TestCaseDummy { Testx = "TestMethod" });
		suite.Add(new TestCaseDummy { Testx = "TestFail" });
		UUnitTestResult result = suite.Run(null);
		UUnitAssert.EqualString("2 run, 1 failed", result.Summary(), "Suite");
	}
	
	[UUnitTest]
	void TestTestSuiteAddAll()
	{
		UUnitTestSuite suite = new UUnitTestSuite();
		suite.AddAll(new TestCaseDummy());
		UUnitTestResult result = suite.Run(null);
		UUnitAssert.EqualString("2 run, 1 failed", result.Summary(), "Suite");
	}
}
