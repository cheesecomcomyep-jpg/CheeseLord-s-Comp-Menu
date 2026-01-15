using System;
using HarmonyLib;
using UnityEngine;

namespace XENONTEMP.Patches
{
	// Token: 0x02000012 RID: 18
	[HarmonyPatch(typeof(GorillaNot), "CheckReports")]
	public class NoCheckReports : MonoBehaviour
	{
		// Token: 0x06000052 RID: 82 RVA: 0x00004FD8 File Offset: 0x000031D8
		private static bool Prefix()
		{
			return false;
		}
	}
}
