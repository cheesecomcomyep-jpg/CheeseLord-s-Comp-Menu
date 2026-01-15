using System;
using System.Reflection;
using HarmonyLib;
using UnityEngine;

namespace XENONTEMP.Patches
{
	// Token: 0x0200000E RID: 14
	public class Menu : MonoBehaviour
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000047 RID: 71 RVA: 0x00004EF0 File Offset: 0x000030F0
		// (set) Token: 0x06000048 RID: 72 RVA: 0x00004EF7 File Offset: 0x000030F7
		public static bool IsPatched { get; private set; }

		// Token: 0x06000049 RID: 73 RVA: 0x00004F00 File Offset: 0x00003100
		internal static void ApplyHarmonyPatches()
		{
			bool flag = !Menu.IsPatched;
			if (flag)
			{
				bool flag2 = Menu.instance == null;
				if (flag2)
				{
					Menu.instance = new Harmony("by.cheeselord");
				}
				Menu.instance.PatchAll(Assembly.GetExecutingAssembly());
				Menu.IsPatched = true;
			}
		}

		// Token: 0x0600004A RID: 74 RVA: 0x00004F50 File Offset: 0x00003150
		internal static void RemoveHarmonyPatches()
		{
			bool flag = Menu.instance != null && Menu.IsPatched;
			if (flag)
			{
				Menu.IsPatched = false;
			}
		}

		// Token: 0x040000E1 RID: 225
		private static Harmony instance;
	}
}
