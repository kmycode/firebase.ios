using System;
using ObjCRuntime;

[assembly: LinkWith ("FirebaseInstanceID.a", LinkTarget.ArmV7 | LinkTarget.Simulator, ForceLoad = true)]
