using System;
using HarmonyLib;
using UnityEngine;

namespace XENONTEMP.Patches
{
	// Token: 0x0200000F RID: 15
	[HarmonyPatch(typeof(GorillaNot), "SendReport")]
	internal class AntiCheat : MonoBehaviour
	{
		// Token: 0x0600004C RID: 76 RVA: 0x00004F84 File Offset: 0x00003184
		private static bool Prefix(string susReason, string susId, string susNick)
		{
			return false;
		}
	}
}
