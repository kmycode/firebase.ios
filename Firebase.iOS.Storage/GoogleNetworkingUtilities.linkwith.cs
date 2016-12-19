using System;
using ObjCRuntime;

[assembly: LinkWith ("GoogleNetworkingUtilities.a", LinkTarget.Simulator | LinkTarget.ArmV7, ForceLoad = true)]
