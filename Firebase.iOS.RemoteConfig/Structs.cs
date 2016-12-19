using System;
using ObjCRuntime;

namespace Firebase.iOS.RemoteConfig
{
	[Native]
	public enum FIRRemoteConfigFetchStatus : long
	{
		NoFetchYet,
		Success,
		Failure,
		Throttled
	}

	[Native]
	public enum FIRRemoteConfigError : long
	{
		Unknown = 8001,
		Throttled = 8002,
		InternalError = 8003
	}

	[Native]
	public enum FIRRemoteConfigSource : long
	{
		Remote,
		Default,
		Static
	}
}

