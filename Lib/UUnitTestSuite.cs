//using UnityEngine;
using System;
using System.Collections.Generic;
using System.Reflection;



public class UUnitTestSuite
{
	List<UUnitTestCase> _tests = new List<UUnitTestCase>();
	UUnitTestResult _result;
	
	public void Add(UUnitTestCase test)
	{
		_tests.Add(test);
	}
	
	public UUnitTestResult RunAllowingExceptions(UUnitTestResult result)
	{
		foreach (UUnitTestCase test in _tests)
			result = test.RunAllowingExceptions(result);
		return result;
	}
		
	public UUnitTestResult Run(UUnitTestResult result)
	{
		foreach (UUnitTestCase test in _tests)
			result = test.Run(result);
		return result;
	}

	public void AddAll(UUnitTestCase aTestCase)
	{
		Type theType = aTestCase.GetType();
		foreach (MethodInfo methodInformation in theType.GetMethods()) {
			foreach (object attr in methodInformation.GetCustomAttributes(inherit: false))
			{
				Attribute testAttr = attr as Attribute;
				if (testAttr != null) {
					ConstructorInfo[] ci = theType.GetConstructors();
					UUnitTestCase temp = (UUnitTestCase)ci[0].Invoke(null);
					temp.SetTest(methodInformation.Name);
					Add(temp);
				}
			}
		}
	}
}
