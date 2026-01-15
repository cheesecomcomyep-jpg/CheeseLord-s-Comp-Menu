using System;
using XENONTEMP.Menu;

namespace XENONTEMP.Mods
{
	// Token: 0x0200001E RID: 30
	internal class SettingsMods
	{
		// Token: 0x06000073 RID: 115 RVA: 0x000057F9 File Offset: 0x000039F9
		public static void EnterSettings()
		{
			Main.buttonsType = 1;
			Main.pageNumber = 0;
		}

		// Token: 0x06000074 RID: 116 RVA: 0x00005808 File Offset: 0x00003A08
		public static void Safety()
		{
			Main.buttonsType = 2;
			Main.pageNumber = 0;
		}

		// Token: 0x06000075 RID: 117 RVA: 0x00005817 File Offset: 0x00003A17
		public static void Movement()
		{
			Main.buttonsType = 3;
			Main.pageNumber = 0;
		}

		// Token: 0x06000076 RID: 118 RVA: 0x00005826 File Offset: 0x00003A26
		public static void Overpowerd()
		{
			Main.buttonsType = 4;
			Main.pageNumber = 0;
		}

		// Token: 0x06000077 RID: 119 RVA: 0x00005835 File Offset: 0x00003A35
		public static void Visuals()
		{
			Main.buttonsType = 5;
			Main.pageNumber = 0;
		}

		// Token: 0x06000078 RID: 120 RVA: 0x00005844 File Offset: 0x00003A44
		public static void Master()
		{
			Main.buttonsType = 6;
			Main.pageNumber = 0;
		}

		// Token: 0x06000079 RID: 121 RVA: 0x00005853 File Offset: 0x00003A53
		public static void Projectiles()
		{
			Main.buttonsType = 7;
			Main.pageNumber = 0;
		}

		// Token: 0x0600007A RID: 122 RVA: 0x00005862 File Offset: 0x00003A62
		public static void Fun()
		{
			Main.buttonsType = 8;
			Main.pageNumber = 0;
		}

		// Token: 0x0600007B RID: 123 RVA: 0x00005871 File Offset: 0x00003A71
		public static void VRRIG()
		{
			Main.buttonsType = 9;
			Main.pageNumber = 0;
		}

		// Token: 0x0600007C RID: 124 RVA: 0x00005881 File Offset: 0x00003A81
		public static void Guardian()
		{
			Main.buttonsType = 10;
			Main.pageNumber = 0;
		}

		// Token: 0x0600007D RID: 125 RVA: 0x00005891 File Offset: 0x00003A91
		public static void advanteges()
		{
			Main.buttonsType = 11;
			Main.pageNumber = 0;
		}

		// Token: 0x0600007E RID: 126 RVA: 0x000058A1 File Offset: 0x00003AA1
		public static void RightHand()
		{
			Settings.rightHanded = true;
		}

		// Token: 0x0600007F RID: 127 RVA: 0x000058AA File Offset: 0x00003AAA
		public static void LeftHand()
		{
			Settings.rightHanded = false;
		}

		// Token: 0x06000080 RID: 128 RVA: 0x000058B3 File Offset: 0x00003AB3
		public static void EnableFPSCounter()
		{
			Settings.fpsCounter = true;
		}

		// Token: 0x06000081 RID: 129 RVA: 0x000058BC File Offset: 0x00003ABC
		public static void DisableFPSCounter()
		{
			Settings.fpsCounter = false;
		}

		// Token: 0x06000082 RID: 130 RVA: 0x000058C5 File Offset: 0x00003AC5
		public static void EnableNotifications()
		{
			Settings.disableNotifications = false;
		}

		// Token: 0x06000083 RID: 131 RVA: 0x000058CE File Offset: 0x00003ACE
		public static void DisableNotifications()
		{
			Settings.disableNotifications = true;
		}

		// Token: 0x06000084 RID: 132 RVA: 0x000058D7 File Offset: 0x00003AD7
		public static void EnableAni4()
		{
			Main.Ani4 = true;
		}

		// Token: 0x06000085 RID: 133 RVA: 0x000058E0 File Offset: 0x00003AE0
		public static void DisableAni4()
		{
			Main.Ani4 = false;
		}

		// Token: 0x06000086 RID: 134 RVA: 0x000058E9 File Offset: 0x00003AE9
		public static void yesround()
		{
			Main.noround = true;
		}

		// Token: 0x06000087 RID: 135 RVA: 0x000058F2 File Offset: 0x00003AF2
		public static void noround()
		{
			Main.noround = false;
		}

		// Token: 0x06000088 RID: 136 RVA: 0x000058FB File Offset: 0x00003AFB
		public static void EnableOutline()
		{
			Main.Outlineint = true;
		}

		// Token: 0x06000089 RID: 137 RVA: 0x00005904 File Offset: 0x00003B04
		public static void DisableOutline()
		{
			Main.Outlineint = false;
		}

		// Token: 0x0600008A RID: 138 RVA: 0x0000590D File Offset: 0x00003B0D
		public static void EnableDisconnectButton()
		{
			Settings.disconnectButton = true;
		}

		// Token: 0x0600008B RID: 139 RVA: 0x00005916 File Offset: 0x00003B16
		public static void DisableDisconnectButton()
		{
			Settings.disconnectButton = false;
		}
	}
}
