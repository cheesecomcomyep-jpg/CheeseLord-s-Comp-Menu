using System;
using HarmonyLib;
using UnityEngine;

namespace XENONTEMP.Patches
{
	// Token: 0x02000010 RID: 16
	[HarmonyPatch(typeof(GorillaNot), "LogErrorCount")]
	public class NoLogErrorCount : MonoBehaviour
	{
		// Token: 0x0600004E RID: 78 RVA: 0x00004FA0 File Offset: 0x000031A0
		private static bool Prefix(string logString, string stackTrace, LogType type)
		{
			return false;
		}
	}
}
