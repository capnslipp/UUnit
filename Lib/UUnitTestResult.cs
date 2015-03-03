//using UnityEngine;



public class UUnitTestResult
{
	int _runCount = 0;
	public int runCount {
		get { return _runCount; }
	}
	
	int _failedCount = 0;
	public int failedCount {
		get { return _failedCount; }
	}
	
	public void TestStarted()
	{
		_runCount += 1;
	}

	public void TestFailed()
	{
		_failedCount += 1;
	}

	public string Summary()
	{
		return this.runCount+" run, "+this.failedCount+" failed";
	}
}
