using System;
using System.ComponentModel;
using BepInEx;

namespace XENONTEMP.Patches
{
	// Token: 0x02000018 RID: 24
	[Description(":3")]
	[BepInPlugin("by.cheeselord", "Comp", "1.0.0")]
	public class HarmonyPatches : BaseUnityPlugin
	{
		// Token: 0x0600005E RID: 94 RVA: 0x00005080 File Offset: 0x00003280
		private void OnEnable()
		{
			Menu.ApplyHarmonyPatches();
		}

		// Token: 0x0600005F RID: 95 RVA: 0x00005089 File Offset: 0x00003289
		private void OnDisable()
		{
			Menu.RemoveHarmonyPatches();
		}
	}
}
