using System;
using HarmonyLib;
using UnityEngine;

namespace XENONTEMP.Patches
{
	// Token: 0x02000015 RID: 21
	[HarmonyPatch(typeof(GorillaNot), "GetRPCCallTracker")]
	internal class NoGetRPCCallTracker : MonoBehaviour
	{
		// Token: 0x06000058 RID: 88 RVA: 0x0000502C File Offset: 0x0000322C
		private static bool Prefix()
		{
			return false;
		}
	}
}
