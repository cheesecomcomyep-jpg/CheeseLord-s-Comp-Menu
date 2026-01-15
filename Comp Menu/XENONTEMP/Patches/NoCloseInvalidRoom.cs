using System;
using HarmonyLib;
using UnityEngine;

namespace XENONTEMP.Patches
{
	// Token: 0x02000011 RID: 17
	[HarmonyPatch(typeof(GorillaNot), "CloseInvalidRoom")]
	public class NoCloseInvalidRoom : MonoBehaviour
	{
		// Token: 0x06000050 RID: 80 RVA: 0x00004FBC File Offset: 0x000031BC
		private static bool Prefix()
		{
			return false;
		}
	}
}
