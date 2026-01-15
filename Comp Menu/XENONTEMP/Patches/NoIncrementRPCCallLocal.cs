using System;
using HarmonyLib;
using UnityEngine;

namespace XENONTEMP.Patches
{
	// Token: 0x02000014 RID: 20
	[HarmonyPatch(typeof(GorillaNot), "IncrementRPCCallLocal")]
	public class NoIncrementRPCCallLocal : MonoBehaviour
	{
		// Token: 0x06000056 RID: 86 RVA: 0x00005010 File Offset: 0x00003210
		private static bool Prefix(PhotonMessageInfoWrapped infoWrapped, string rpcFunction)
		{
			return false;
		}
	}
}
