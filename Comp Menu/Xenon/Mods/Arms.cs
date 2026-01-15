using System;
using UnityEngine;

namespace Xenon.Mods
{
	// Token: 0x02000004 RID: 4
	internal class Arms
	{
		// Token: 0x06000012 RID: 18 RVA: 0x000028BD File Offset: 0x00000ABD
		public static void LongArms()
		{
			GorillaTagger.Instance.transform.localScale = new Vector3(1.45f, 1.45f, 1.45f);
		}

		// Token: 0x06000013 RID: 19 RVA: 0x000028E4 File Offset: 0x00000AE4
		public static void SteamArms()
		{
			GorillaTagger.Instance.transform.localScale = new Vector3(1.25f, 1.25f, 1.25f);
		}

		// Token: 0x06000014 RID: 20 RVA: 0x0000290B File Offset: 0x00000B0B
		public static void ShortArms()
		{
			GorillaTagger.Instance.transform.localScale = new Vector3(0.75f, 0.75f, 0.75f);
		}

		// Token: 0x06000015 RID: 21 RVA: 0x00002932 File Offset: 0x00000B32
		public static void NoArms()
		{
			GorillaTagger.Instance.transform.localScale = new Vector3(0f, 0f, 0f);
		}

		// Token: 0x06000016 RID: 22 RVA: 0x00002959 File Offset: 0x00000B59
		public static void ToLongArms()
		{
			GorillaTagger.Instance.transform.localScale = new Vector3(2.25f, 2.25f, 2.25f);
		}

		// Token: 0x06000017 RID: 23 RVA: 0x00002980 File Offset: 0x00000B80
		public static void VeryVeryLongArms()
		{
			GorillaTagger.Instance.transform.localScale = new Vector3(6.25f, 6.25f, 6.25f);
		}

		// Token: 0x06000018 RID: 24 RVA: 0x000029A7 File Offset: 0x00000BA7
		public static void CustomArmsPlus()
		{
			Arms.CustomArmIndex += 1f;
		}

		// Token: 0x06000019 RID: 25 RVA: 0x000029BA File Offset: 0x00000BBA
		public static void CustomArmsNegitive()
		{
			Arms.CustomArmIndex -= 1f;
		}

		// Token: 0x0600001A RID: 26 RVA: 0x000029CD File Offset: 0x00000BCD
		public static void CustomArms()
		{
			GorillaTagger.Instance.transform.localScale = new Vector3(Arms.CustomArmIndex, Arms.CustomArmIndex, Arms.CustomArmIndex);
		}

		// Token: 0x04000011 RID: 17
		public static float CustomArmIndex = 1f;
	}
}
