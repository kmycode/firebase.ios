using System;
using ObjCRuntime;

[assembly: LinkWith ("GoogleIPhoneUtilities.a", LinkTarget.ArmV7 | LinkTarget.Simulator, ForceLoad = true)]
