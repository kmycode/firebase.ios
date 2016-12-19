using System;
using ObjCRuntime;

[assembly: LinkWith ("GoogleSymbolUtilities.a", LinkTarget.Simulator | LinkTarget.ArmV7, ForceLoad = true)]
