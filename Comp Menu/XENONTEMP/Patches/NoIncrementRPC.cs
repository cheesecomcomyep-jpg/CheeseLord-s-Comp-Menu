using System;
using HarmonyLib;
using UnityEngine;

namespace XENONTEMP.Patches
{
	// Token: 0x02000017 RID: 23
	[HarmonyPatch(typeof(VRRig), "IncrementRPC", new Type[]
	{
		typeof(PhotonMessageInfoWrapped),
		typeof(string)
	})]
	public class NoIncrementRPC : MonoBehaviour
	{
		// Token: 0x0600005C RID: 92 RVA: 0x00005064 File Offset: 0x00003264
		private static bool Prefix(PhotonMessageInfoWrapped info, string sourceCall)
		{
			return false;
		}
	}
}
