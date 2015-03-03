//using UnityEngine;
using System;



public class UUnitAssertException : Exception
{
	public object expected;
	public object received;
	public string msg;
	
	public UUnitAssertException(object expected, object received, string msg)
	{
		this.expected = expected;
		this.received = received;
		this.msg = msg;
	}
	
	public override string Message {
		get {
			return "[UUnit] - Assert Failed - Expected: "+this.expected+" Received: "+this.received + "\n" +
				"\t\t" + "("+this.msg+")";
		}
	}
}
