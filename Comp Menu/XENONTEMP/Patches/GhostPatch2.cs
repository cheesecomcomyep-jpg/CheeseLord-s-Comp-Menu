using System;
using HarmonyLib;

namespace XENONTEMP.Patches
{
	// Token: 0x0200001A RID: 26
	[HarmonyPatch(typeof(VRRigJobManager), "DeregisterVRRig")]
	public static class GhostPatch2
	{
		// Token: 0x06000063 RID: 99 RVA: 0x000050CC File Offset: 0x000032CC
		public static bool Prefix(VRRigJobManager __instance, VRRig rig)
		{
			return !(__instance == GorillaTagger.Instance.offlineVRRig);
		}
	}
}
