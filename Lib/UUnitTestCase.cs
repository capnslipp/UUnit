using System;
using System.Reflection;
using UnityEngine;



public class UUnitTestCase
{
	protected object local;
	
	string _test;
	public string Testx {
		get { return _test; }
		set { _test = value; }
	}
	
	public UUnitTestCase() {}
	
	public void SetTest(string aMethod)
	{
		_test = aMethod;
	}
	
	public UUnitTestResult RunAllowingExceptions(UUnitTestResult result)
	{
		if (result == null)
			result = new UUnitTestResult();
		
		this.SetUp();
		result.TestStarted();
		
		Type selfType = this.GetType();
		MethodInfo myMethInfo = selfType.GetMethod(_test);
		myMethInfo.Invoke(this, null);
		return result;
	}
	
	public UUnitTestResult Run(UUnitTestResult result)
	{
		if (result == null)
			result = new UUnitTestResult();
		
		this.SetUp();
		result.TestStarted();
		
		try {
			Type selfType = this.GetType();
			MethodInfo myMethInfo = selfType.GetMethod(_test);
			myMethInfo.Invoke(this, null);
		} catch (TargetInvocationException e) {
			result.TestFailed();
			Debug.Log(e.InnerException);
		}
		return result;
	}
	
	protected virtual void SetUp() {}
}
