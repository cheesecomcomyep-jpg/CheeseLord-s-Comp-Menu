using System;
using HarmonyLib;
using UnityEngine;

namespace XENONTEMP.Patches
{
	// Token: 0x0200001B RID: 27
	[HarmonyPatch(typeof(GameObject))]
	[HarmonyPatch("CreatePrimitive", 0)]
	internal class ShaderFix : MonoBehaviour
	{
		// Token: 0x06000064 RID: 100 RVA: 0x000050F4 File Offset: 0x000032F4
		private static void Postfix(GameObject __result)
		{
			__result.GetComponent<Renderer>().material.shader = Shader.Find("GorillaTag/UberShader");
			__result.GetComponent<Renderer>().material.color = new Color32(byte.MaxValue, 128, 0, 128);
		}
	}
}
