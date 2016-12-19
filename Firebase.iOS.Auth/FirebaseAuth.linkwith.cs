using System;
using ObjCRuntime;

[assembly: LinkWith ("FirebaseAuth.a", LinkTarget.ArmV7 | LinkTarget.Simulator, ForceLoad = true, SmartLink = true, LinkerFlags = "-lstdc++ -lz -lsqlite3 -licucore")]
