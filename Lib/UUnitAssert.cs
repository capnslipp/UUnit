//using UnityEngine;
using System;



public static class UUnitAssert
{
	public static void True(bool boolean, string msg)
	{
		if (boolean)
			return;
		
		throw new UUnitAssertException(true, false, msg);
	}
		
	public static void False(bool boolean, string msg)
	{
		if (!boolean)
			return;
		
		throw new UUnitAssertException(false, true, msg);
	}
		
	public static void EqualInt(int wanted, int got, string msg)
	{
		if (wanted == got)
			return;
		
		throw new UUnitAssertException(wanted, got, msg);
	}
	
	public static void EqualString(string wanted, string got, string msg)
	{
		if (wanted == got)
			return;
		
		throw new UUnitAssertException(wanted, got, msg);
	}
	
	public static void Equal<T>(T wanted, T got, string msg)
	{
		if (wanted.Equals(got))
			return;
		
		throw new UUnitAssertException(wanted, got, msg);
	}
	
	[Obsolete("EqualDuck() is obsolete.  Please use Equal<T>() instead.", error: true)]
	public static void EqualDuck(object wanted, object got, string msg) {}
}
