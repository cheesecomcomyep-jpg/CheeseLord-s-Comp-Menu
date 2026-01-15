using System;
using HarmonyLib;
using Photon.Pun;
using UnityEngine;

namespace XENONTEMP.Patches
{
	// Token: 0x02000016 RID: 22
	[HarmonyPatch(typeof(GorillaNot), "IncrementRPCCall", new Type[]
	{
		typeof(PhotonMessageInfo),
		typeof(string)
	})]
	public class NoIncrementRPCCall : MonoBehaviour
	{
		// Token: 0x0600005A RID: 90 RVA: 0x00005048 File Offset: 0x00003248
		private static bool Prefix(PhotonMessageInfo info, string callingMethod = "")
		{
			return false;
		}
	}
}
