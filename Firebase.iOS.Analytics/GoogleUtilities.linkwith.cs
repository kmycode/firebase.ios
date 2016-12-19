using System;
using ObjCRuntime;

[assembly: LinkWith ("GoogleUtilities.a", LinkTarget.Simulator | LinkTarget.ArmV7, ForceLoad = true)]
