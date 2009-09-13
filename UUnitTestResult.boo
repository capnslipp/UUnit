#import UnityEngine

class UUnitTestResult():
	[Getter(runCount)] 
	_runCount = 0
	
	[Getter(failedCount)] 
	_failedCount = 0

	def TestStarted():
		_runCount += 1

	def TestFailed():
		_failedCount += 1

	def Summary():
		return "${runCount} run, ${failedCount} failed"