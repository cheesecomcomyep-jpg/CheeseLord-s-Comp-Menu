using System;
using HarmonyLib;
using UnityEngine;

namespace XENONTEMP.Patches
{
	// Token: 0x02000019 RID: 25
	[HarmonyPatch(typeof(VRRig), "OnDisable")]
	internal class GhostPatch : MonoBehaviour
	{
		// Token: 0x06000061 RID: 97 RVA: 0x0000509C File Offset: 0x0000329C
		public static bool Prefix(VRRig __instance)
		{
			return !(__instance == GorillaTagger.Instance.offlineVRRig);
		}
	}
}
