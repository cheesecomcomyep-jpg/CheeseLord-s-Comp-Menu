using System;
using Gunlib;
using Photon.Pun;
using XENONTEMP.Menu;

namespace XENONTEMP.Mods
{
	// Token: 0x0200001D RID: 29
	internal class Global
	{
		// Token: 0x0600006E RID: 110 RVA: 0x000057A6 File Offset: 0x000039A6
		public static void ReturnHome()
		{
			Main.buttonsType = 0;
			Main.pageNumber = 0;
			Main.shouldHome = false;
		}

		// Token: 0x0600006F RID: 111 RVA: 0x000057BB File Offset: 0x000039BB
		public static void Gun()
		{
			GunTemplate.StartBothGuns(delegate
			{
			}, true);
		}

		// Token: 0x06000070 RID: 112 RVA: 0x000057E4 File Offset: 0x000039E4
		public static void placeholder()
		{
		}

		// Token: 0x06000071 RID: 113 RVA: 0x000057E7 File Offset: 0x000039E7
		public static void idkthethefuckimdoingthis()
		{
			PhotonNetwork.Disconnect();
		}
	}
}
