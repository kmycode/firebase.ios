using System;
using ObjCRuntime;

[assembly: LinkWith ("FirebaseDatabase.a", LinkTarget.ArmV7 | LinkTarget.ArmV7s | LinkTarget.Simulator, ForceLoad = true, SmartLink = true, LinkerFlags = "-lstdc++ -lz -lsqlite3 -licucore")]
