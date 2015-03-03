using UnityEngine;



internal class TestCaseRunner : MonoBehaviour
{
	protected void Start()
	{
		UUnitTestSuite suite = new UUnitTestSuite();
		suite.AddAll(new TestCaseTest());
		UUnitTestResult result = suite.Run(null);
		Debug.Log(result.Summary());
	}
}
