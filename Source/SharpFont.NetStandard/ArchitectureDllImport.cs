using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;

namespace SharpFont.NetStandard
{
	public static class ArchitectureDllImport
	{
		public const string DefaultDllDirectory = "";
		public static Dictionary<Architecture, string> ArchitectureDlls = new Dictionary<Architecture, string>()
		{
			{ Architecture.X64, "x64" },
			{ Architecture.X86, "x86" },
			{ Architecture.Arm, DefaultDllDirectory },
			{ Architecture.Arm64, DefaultDllDirectory }
		};

		[DllImport("kernel32.dll", SetLastError = true)]
		public static extern bool SetDllDirectory(string lpPathName);

		public static void LoadArchitectureDependencyDirectory()
		{
			if (!ArchitectureDlls.TryGetValue(RuntimeInformation.ProcessArchitecture, out var dllPath))
			{
				dllPath = DefaultDllDirectory;
			}

			if (!string.IsNullOrWhiteSpace(dllPath))
			{
				SetDllDirectory(String.Concat(Directory.GetCurrentDirectory(), "lib", dllPath));
			}
		}
	}
}
