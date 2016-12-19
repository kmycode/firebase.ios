using System;
using ObjCRuntime;

[assembly: LinkWith ("GoogleInterchangeUtilities.a", LinkTarget.Simulator | LinkTarget.ArmV7, ForceLoad = true)]
