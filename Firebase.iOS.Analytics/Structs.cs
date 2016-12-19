using System;
using System.Runtime.InteropServices;
using ObjCRuntime;
using Foundation;
using UIKit;

namespace Firebase.iOS.Analytics
{
}

// Analytics.a
namespace Firebase.iOS.Analytics
{
	static class CFunctions
	{
		// extern int NS_ENUM (int NSInteger, int FIRDataEventType);
		//[DllImport("__Internal")]
		//[Verify(PlatformInvoke)]
		//static extern int NS_ENUM(int NSInteger, int FIRDataEventType);
	}

	[Native]
	public enum FIRLogLevel : long
	{
		Error = 0,
		Warning,
		Info,
		Debug,
		Assert,
		Max = Assert
	}
}

// InstanceID.a
namespace Firebase.iOS.Analytics
{
	[Native]
	public enum FIRInstanceIDError : ulong
	{
		Unknown = 0,
		Authentication = 1,
		NoAccess = 2,
		Timeout = 3,
		Network = 4,
		OperationInProgress = 5,
		InvalidRequest = 7
	}

	[Native]
	public enum FIRInstanceIDAPNSTokenType : long
	{
		Unknown,
		Sandbox,
		Prod
	}
}
