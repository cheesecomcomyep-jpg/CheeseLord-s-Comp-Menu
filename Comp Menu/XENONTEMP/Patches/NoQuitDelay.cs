using System;
using HarmonyLib;
using UnityEngine;

namespace XENONTEMP.Patches
{
	// Token: 0x02000013 RID: 19
	[HarmonyPatch(typeof(GorillaNot), "QuitDelay", 5)]
	public class NoQuitDelay : MonoBehaviour
	{
		// Token: 0x06000054 RID: 84 RVA: 0x00004FF4 File Offset: 0x000031F4
		private static bool Prefix()
		{
			return false;
		}
	}
}
