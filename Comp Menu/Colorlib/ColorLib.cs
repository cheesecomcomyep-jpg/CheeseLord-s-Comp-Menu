using System;
using UnityEngine;

namespace Colorlib
{
	// Token: 0x02000009 RID: 9
	public class ColorLib
	{
		// Token: 0x0600003D RID: 61 RVA: 0x000032C4 File Offset: 0x000014C4
		public static void UpdateClr()
		{
			float num = Mathf.PingPong(Time.time * 0.3f, 1f);
			float num2 = 0.75f;
			ColorLib.RGB.color = Color.HSVToRGB(num, 1f, num2);
			ColorLib.hexColor = "#" + ColorUtility.ToHtmlStringRGB(ColorLib.RGB.color);
			ColorLib.hexColor1 = "#" + ColorUtility.ToHtmlStringRGB(ColorLib.DFade.color);
			ColorLib.DFade.color = Color.Lerp(ColorLib.Indigo, ColorLib.DarkPurple, Mathf.PingPong(Time.time, 1f));
			ColorLib.DBreath.color = Color.Lerp(ColorLib.Indigo, ColorLib.DarkPurple, Mathf.PingPong(Time.time, 1.5f));
		}

		// Token: 0x04000016 RID: 22
		public static Color32 purple123 = new Color32(25, 25, 25, byte.MaxValue);

		// Token: 0x04000017 RID: 23
		public static Color32 idk = new Color32(111, 252, 243, byte.MaxValue);

		// Token: 0x04000018 RID: 24
		public static Color32 Red = new Color32(byte.MaxValue, 0, 0, byte.MaxValue);

		// Token: 0x04000019 RID: 25
		public static Color32 DarkRed = new Color32(180, 0, 0, byte.MaxValue);

		// Token: 0x0400001A RID: 26
		public static Color32 Salmon = new Color32(250, 128, 114, byte.MaxValue);

		// Token: 0x0400001B RID: 27
		public static Color32 WineRed = new Color32(123, 0, 0, byte.MaxValue);

		// Token: 0x0400001C RID: 28
		public static Color32 IndianRed = new Color32(205, 92, 92, byte.MaxValue);

		// Token: 0x0400001D RID: 29
		public static Color32 Crimson = new Color32(220, 20, 60, byte.MaxValue);

		// Token: 0x0400001E RID: 30
		public static Color32 FireBrick = new Color32(178, 34, 34, byte.MaxValue);

		// Token: 0x0400001F RID: 31
		public static Color32 Coral = new Color32(byte.MaxValue, 127, 80, byte.MaxValue);

		// Token: 0x04000020 RID: 32
		public static Color32 DarkCoral = new Color32(235, 107, 60, byte.MaxValue);

		// Token: 0x04000021 RID: 33
		public static Color32 Tomato = new Color32(byte.MaxValue, 99, 71, byte.MaxValue);

		// Token: 0x04000022 RID: 34
		public static Color32 Maroon = new Color32(128, 0, 0, byte.MaxValue);

		// Token: 0x04000023 RID: 35
		public static Color32 Green = new Color32(0, byte.MaxValue, 0, byte.MaxValue);

		// Token: 0x04000024 RID: 36
		public static Color32 Lime = new Color32(0, 128, 0, byte.MaxValue);

		// Token: 0x04000025 RID: 37
		public static Color32 DarkGreen = new Color32(0, 100, 0, byte.MaxValue);

		// Token: 0x04000026 RID: 38
		public static Color32 Olive = new Color32(128, 128, 0, byte.MaxValue);

		// Token: 0x04000027 RID: 39
		public static Color32 ForestGreen = new Color32(34, 139, 34, byte.MaxValue);

		// Token: 0x04000028 RID: 40
		public static Color32 SeaGreen = new Color32(46, 139, 87, byte.MaxValue);

		// Token: 0x04000029 RID: 41
		public static Color32 MediumSeaGreen = new Color32(60, 179, 113, byte.MaxValue);

		// Token: 0x0400002A RID: 42
		public static Color32 Aquamarine = new Color32(127, byte.MaxValue, 212, byte.MaxValue);

		// Token: 0x0400002B RID: 43
		public static Color32 MediumAquamarine = new Color32(102, 205, 170, byte.MaxValue);

		// Token: 0x0400002C RID: 44
		public static Color32 DarkSeaGreen = new Color32(143, 188, 143, byte.MaxValue);

		// Token: 0x0400002D RID: 45
		public static Color32 Blue = new Color32(0, 0, byte.MaxValue, byte.MaxValue);

		// Token: 0x0400002E RID: 46
		public static Color32 Navy = new Color32(0, 0, 128, byte.MaxValue);

		// Token: 0x0400002F RID: 47
		public static Color32 DarkBlue = new Color32(0, 0, 160, byte.MaxValue);

		// Token: 0x04000030 RID: 48
		public static Color32 RoyalBlue = new Color32(65, 105, 225, byte.MaxValue);

		// Token: 0x04000031 RID: 49
		public static Color32 DodgerBlue = new Color32(30, 144, byte.MaxValue, byte.MaxValue);

		// Token: 0x04000032 RID: 50
		public static Color32 DarkDodgerBlue = new Color32(8, 90, 177, byte.MaxValue);

		// Token: 0x04000033 RID: 51
		public static Color32 DeepSkyBlue = new Color32(0, 191, byte.MaxValue, byte.MaxValue);

		// Token: 0x04000034 RID: 52
		public static Color32 SkyBlue = new Color32(135, 206, 235, byte.MaxValue);

		// Token: 0x04000035 RID: 53
		public static Color32 SteelBlue = new Color32(70, 130, 180, byte.MaxValue);

		// Token: 0x04000036 RID: 54
		public static Color32 Cyan = new Color32(0, byte.MaxValue, byte.MaxValue, byte.MaxValue);

		// Token: 0x04000037 RID: 55
		public static Color32 Yellow = new Color32(byte.MaxValue, byte.MaxValue, 0, byte.MaxValue);

		// Token: 0x04000038 RID: 56
		public static Color32 Gold = new Color32(byte.MaxValue, 215, 0, byte.MaxValue);

		// Token: 0x04000039 RID: 57
		public static Color32 LightYellow = new Color32(byte.MaxValue, byte.MaxValue, 224, byte.MaxValue);

		// Token: 0x0400003A RID: 58
		public static Color32 LemonChiffon = new Color32(byte.MaxValue, 250, 205, byte.MaxValue);

		// Token: 0x0400003B RID: 59
		public static Color32 Khaki = new Color32(240, 230, 140, byte.MaxValue);

		// Token: 0x0400003C RID: 60
		public static Color32 PaleGoldenrod = new Color32(238, 232, 170, byte.MaxValue);

		// Token: 0x0400003D RID: 61
		public static Color32 LightGoldenrodYellow = new Color32(250, 250, 210, byte.MaxValue);

		// Token: 0x0400003E RID: 62
		public static Color32 Orange = new Color32(byte.MaxValue, 165, 0, byte.MaxValue);

		// Token: 0x0400003F RID: 63
		public static Color32 DarkOrange = new Color32(byte.MaxValue, 140, 0, byte.MaxValue);

		// Token: 0x04000040 RID: 64
		public static Color32 RedOrange = new Color32(byte.MaxValue, 69, 0, byte.MaxValue);

		// Token: 0x04000041 RID: 65
		public static Color32 PeachPuff = new Color32(byte.MaxValue, 218, 185, byte.MaxValue);

		// Token: 0x04000042 RID: 66
		public static Color32 DarkGoldenrod = new Color32(184, 134, 11, byte.MaxValue);

		// Token: 0x04000043 RID: 67
		public static Color32 Peru = new Color32(205, 133, 63, byte.MaxValue);

		// Token: 0x04000044 RID: 68
		public static Color32 OrangeRed = new Color32(byte.MaxValue, 69, 0, byte.MaxValue);

		// Token: 0x04000045 RID: 69
		public static Color32 Magenta = new Color32(byte.MaxValue, 0, byte.MaxValue, byte.MaxValue);

		// Token: 0x04000046 RID: 70
		public static Color32 Purple = new Color32(123, 3, 252, byte.MaxValue);

		// Token: 0x04000047 RID: 71
		public static Color32 DarkPurple = new Color32(38, 23, 77, byte.MaxValue);

		// Token: 0x04000048 RID: 72
		public static Color32 Lavender = new Color32(230, 230, 250, byte.MaxValue);

		// Token: 0x04000049 RID: 73
		public static Color32 Plum = new Color32(221, 160, 221, byte.MaxValue);

		// Token: 0x0400004A RID: 74
		public static Color32 Indigo = new Color32(75, 0, 130, byte.MaxValue);

		// Token: 0x0400004B RID: 75
		public static Color32 MediumOrchid = new Color32(186, 85, 211, byte.MaxValue);

		// Token: 0x0400004C RID: 76
		public static Color32 SlateBlue = new Color32(106, 90, 205, byte.MaxValue);

		// Token: 0x0400004D RID: 77
		public static Color32 DarkSlateBlue = new Color32(72, 61, 139, byte.MaxValue);

		// Token: 0x0400004E RID: 78
		public static Color32 Pink = new Color32(byte.MaxValue, 192, 203, byte.MaxValue);

		// Token: 0x0400004F RID: 79
		public static Color32 LightSalmon = new Color32(byte.MaxValue, 160, 122, byte.MaxValue);

		// Token: 0x04000050 RID: 80
		public static Color32 DarkSalmon = new Color32(233, 150, 122, byte.MaxValue);

		// Token: 0x04000051 RID: 81
		public static Color32 LightCoral = new Color32(240, 128, 128, byte.MaxValue);

		// Token: 0x04000052 RID: 82
		public static Color32 MistyRose = new Color32(byte.MaxValue, 228, 225, byte.MaxValue);

		// Token: 0x04000053 RID: 83
		public static Color32 HotPink = new Color32(byte.MaxValue, 105, 180, byte.MaxValue);

		// Token: 0x04000054 RID: 84
		public static Color32 DeepPink = new Color32(byte.MaxValue, 20, 147, byte.MaxValue);

		// Token: 0x04000055 RID: 85
		public static Color32 Brown = new Color32(139, 69, 19, byte.MaxValue);

		// Token: 0x04000056 RID: 86
		public static Color32 RosyBrown = new Color32(188, 143, 143, byte.MaxValue);

		// Token: 0x04000057 RID: 87
		public static Color32 SaddleBrown = new Color32(139, 69, 19, byte.MaxValue);

		// Token: 0x04000058 RID: 88
		public static Color32 Sienna = new Color32(160, 82, 45, byte.MaxValue);

		// Token: 0x04000059 RID: 89
		public static Color32 Chocolate = new Color32(210, 105, 30, byte.MaxValue);

		// Token: 0x0400005A RID: 90
		public static Color32 SandyBrown = new Color32(244, 164, 96, byte.MaxValue);

		// Token: 0x0400005B RID: 91
		public static Color32 DarkSandyBrown = new Color32(224, 144, 76, byte.MaxValue);

		// Token: 0x0400005C RID: 92
		public static Color32 BurlyWood = new Color32(222, 184, 135, byte.MaxValue);

		// Token: 0x0400005D RID: 93
		public static Color32 Tan = new Color32(210, 180, 140, byte.MaxValue);

		// Token: 0x0400005E RID: 94
		public static Color32 White = new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue);

		// Token: 0x0400005F RID: 95
		public static Color32 Linen = new Color32(250, 240, 230, byte.MaxValue);

		// Token: 0x04000060 RID: 96
		public static Color32 OldLace = new Color32(253, 245, 230, byte.MaxValue);

		// Token: 0x04000061 RID: 97
		public static Color32 SeaShell = new Color32(byte.MaxValue, 245, 238, byte.MaxValue);

		// Token: 0x04000062 RID: 98
		public static Color32 MintCream = new Color32(245, byte.MaxValue, 250, byte.MaxValue);

		// Token: 0x04000063 RID: 99
		public static Color32 Black = new Color32(0, 0, 0, byte.MaxValue);

		// Token: 0x04000064 RID: 100
		public static Color32 Grey = new Color32(128, 128, 128, byte.MaxValue);

		// Token: 0x04000065 RID: 101
		public static Color32 LightGrey = new Color32(192, 192, 192, byte.MaxValue);

		// Token: 0x04000066 RID: 102
		public static Color32 DarkGrey = new Color32(80, 80, 80, byte.MaxValue);

		// Token: 0x04000067 RID: 103
		public static Color32 DarkerGrey = new Color32(40, 40, 40, byte.MaxValue);

		// Token: 0x04000068 RID: 104
		public static Color32 RedTransparent = new Color32(byte.MaxValue, 0, 0, 80);

		// Token: 0x04000069 RID: 105
		public static Color32 DarkRedTransparent = new Color32(180, 0, 0, 80);

		// Token: 0x0400006A RID: 106
		public static Color32 SalmonTransparent = new Color32(250, 128, 114, 80);

		// Token: 0x0400006B RID: 107
		public static Color32 IndianRedTransparent = new Color32(205, 92, 92, 80);

		// Token: 0x0400006C RID: 108
		public static Color32 CrimsonTransparent = new Color32(220, 20, 60, 80);

		// Token: 0x0400006D RID: 109
		public static Color32 WineRedTransparent = new Color32(123, 0, 0, 80);

		// Token: 0x0400006E RID: 110
		public static Color32 FireBrickTransparent = new Color32(178, 34, 34, 80);

		// Token: 0x0400006F RID: 111
		public static Color32 CoralTransparent = new Color32(byte.MaxValue, 127, 80, 80);

		// Token: 0x04000070 RID: 112
		public static Color32 TomatoTransparent = new Color32(byte.MaxValue, 99, 71, 80);

		// Token: 0x04000071 RID: 113
		public static Color32 MaroonTransparent = new Color32(128, 0, 0, 80);

		// Token: 0x04000072 RID: 114
		public static Color32 GreenTransparent = new Color32(0, byte.MaxValue, 0, 80);

		// Token: 0x04000073 RID: 115
		public static Color32 LimeTransparent = new Color32(0, 128, 0, 80);

		// Token: 0x04000074 RID: 116
		public static Color32 DarkGreenTransparent = new Color32(0, 100, 0, 80);

		// Token: 0x04000075 RID: 117
		public static Color32 OliveTransparent = new Color32(128, 128, 0, 80);

		// Token: 0x04000076 RID: 118
		public static Color32 ForestGreenTransparent = new Color32(34, 139, 34, 80);

		// Token: 0x04000077 RID: 119
		public static Color32 SeaGreenTransparent = new Color32(46, 139, 87, 80);

		// Token: 0x04000078 RID: 120
		public static Color32 MediumSeaGreenTransparent = new Color32(60, 179, 113, 80);

		// Token: 0x04000079 RID: 121
		public static Color32 AquamarineTransparent = new Color32(127, byte.MaxValue, 212, 80);

		// Token: 0x0400007A RID: 122
		public static Color32 MediumAquamarineTransparent = new Color32(102, 205, 170, 80);

		// Token: 0x0400007B RID: 123
		public static Color32 DarkSeaGreenTransparent = new Color32(143, 188, 143, 80);

		// Token: 0x0400007C RID: 124
		public static Color32 BlueTransparent = new Color32(0, 0, byte.MaxValue, 80);

		// Token: 0x0400007D RID: 125
		public static Color32 NavyTransparent = new Color32(0, 0, 128, 80);

		// Token: 0x0400007E RID: 126
		public static Color32 DarkBlueTransparent = new Color32(0, 0, 139, 80);

		// Token: 0x0400007F RID: 127
		public static Color32 RoyalBlueTransparent = new Color32(65, 105, 225, 80);

		// Token: 0x04000080 RID: 128
		public static Color32 DodgerBlueTransparent = new Color32(30, 144, byte.MaxValue, 80);

		// Token: 0x04000081 RID: 129
		public static Color32 DarkDodgerBlueTransparent = new Color32(8, 90, 177, 80);

		// Token: 0x04000082 RID: 130
		public static Color32 DeepSkyBlueTransparent = new Color32(0, 191, byte.MaxValue, 80);

		// Token: 0x04000083 RID: 131
		public static Color32 SkyBlueTransparent = new Color32(135, 206, 235, 80);

		// Token: 0x04000084 RID: 132
		public static Color32 SteelBlueTransparent = new Color32(70, 130, 180, 80);

		// Token: 0x04000085 RID: 133
		public static Color32 CyanTransparent = new Color32(0, byte.MaxValue, byte.MaxValue, 80);

		// Token: 0x04000086 RID: 134
		public static Color32 YellowTransparent = new Color32(byte.MaxValue, byte.MaxValue, 0, 80);

		// Token: 0x04000087 RID: 135
		public static Color32 GoldTransparent = new Color32(byte.MaxValue, 215, 0, 80);

		// Token: 0x04000088 RID: 136
		public static Color32 LightYellowTransparent = new Color32(byte.MaxValue, byte.MaxValue, 224, 80);

		// Token: 0x04000089 RID: 137
		public static Color32 LemonChiffonTransparent = new Color32(byte.MaxValue, 250, 205, 80);

		// Token: 0x0400008A RID: 138
		public static Color32 KhakiTransparent = new Color32(240, 230, 140, 80);

		// Token: 0x0400008B RID: 139
		public static Color32 PaleGoldenrodTransparent = new Color32(238, 232, 170, 80);

		// Token: 0x0400008C RID: 140
		public static Color32 LightGoldenrodYellowTransparent = new Color32(250, 250, 210, 80);

		// Token: 0x0400008D RID: 141
		public static Color32 OrangeTransparent = new Color32(byte.MaxValue, 165, 0, 80);

		// Token: 0x0400008E RID: 142
		public static Color32 DarkOrangeTransparent = new Color32(byte.MaxValue, 140, 0, 80);

		// Token: 0x0400008F RID: 143
		public static Color32 RedOrangeTransparent = new Color32(byte.MaxValue, 69, 0, 80);

		// Token: 0x04000090 RID: 144
		public static Color32 PeachPuffTransparent = new Color32(byte.MaxValue, 218, 185, 80);

		// Token: 0x04000091 RID: 145
		public static Color32 DarkGoldenrodTransparent = new Color32(184, 134, 11, 80);

		// Token: 0x04000092 RID: 146
		public static Color32 PeruTransparent = new Color32(205, 133, 63, 80);

		// Token: 0x04000093 RID: 147
		public static Color32 OrangeRedTransparent = new Color32(byte.MaxValue, 69, 0, 80);

		// Token: 0x04000094 RID: 148
		public static Color32 MagentaTransparent = new Color32(byte.MaxValue, 0, byte.MaxValue, 80);

		// Token: 0x04000095 RID: 149
		public static Color32 PurpleTransparent = new Color32(123, 3, 252, 80);

		// Token: 0x04000096 RID: 150
		public static Color32 LavenderTransparent = new Color32(230, 230, 250, 80);

		// Token: 0x04000097 RID: 151
		public static Color32 PlumTransparent = new Color32(221, 160, 221, 80);

		// Token: 0x04000098 RID: 152
		public static Color32 IndigoTransparent = new Color32(75, 0, 130, 80);

		// Token: 0x04000099 RID: 153
		public static Color32 MediumOrchidTransparent = new Color32(186, 85, 211, 80);

		// Token: 0x0400009A RID: 154
		public static Color32 SlateBlueTransparent = new Color32(106, 90, 205, 80);

		// Token: 0x0400009B RID: 155
		public static Color32 DarkSlateBlueTransparent = new Color32(72, 61, 139, 80);

		// Token: 0x0400009C RID: 156
		public static Color32 PinkTransparent = new Color32(byte.MaxValue, 192, 203, 80);

		// Token: 0x0400009D RID: 157
		public static Color32 LightSalmonTransparent = new Color32(byte.MaxValue, 160, 122, 80);

		// Token: 0x0400009E RID: 158
		public static Color32 DarkSalmonTransparent = new Color32(233, 150, 122, 80);

		// Token: 0x0400009F RID: 159
		public static Color32 LightCoralTransparent = new Color32(240, 128, 128, 80);

		// Token: 0x040000A0 RID: 160
		public static Color32 MistyRoseTransparent = new Color32(byte.MaxValue, 228, 225, 80);

		// Token: 0x040000A1 RID: 161
		public static Color32 HotPinkTransparent = new Color32(byte.MaxValue, 105, 180, 80);

		// Token: 0x040000A2 RID: 162
		public static Color32 DeepPinkTransparent = new Color32(byte.MaxValue, 20, 147, 80);

		// Token: 0x040000A3 RID: 163
		public static Color32 BrownTransparent = new Color32(165, 42, 42, 80);

		// Token: 0x040000A4 RID: 164
		public static Color32 RosyBrownTransparent = new Color32(188, 143, 143, 80);

		// Token: 0x040000A5 RID: 165
		public static Color32 SaddleBrownTransparent = new Color32(139, 69, 19, 80);

		// Token: 0x040000A6 RID: 166
		public static Color32 SiennaTransparent = new Color32(160, 82, 45, 80);

		// Token: 0x040000A7 RID: 167
		public static Color32 ChocolateTransparent = new Color32(210, 105, 30, 80);

		// Token: 0x040000A8 RID: 168
		public static Color32 SandyBrownTransparent = new Color32(244, 164, 96, 80);

		// Token: 0x040000A9 RID: 169
		public static Color32 BurlyWoodTransparent = new Color32(222, 184, 135, 80);

		// Token: 0x040000AA RID: 170
		public static Color32 TanTransparent = new Color32(210, 180, 140, 80);

		// Token: 0x040000AB RID: 171
		public static Color32 WhiteTransparent = new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, 80);

		// Token: 0x040000AC RID: 172
		public static Color32 LightWhiteTransparent = new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, 10);

		// Token: 0x040000AD RID: 173
		public static Color32 LinenTransparent = new Color32(250, 240, 230, 80);

		// Token: 0x040000AE RID: 174
		public static Color32 kiwi = new Color32(101, 158, 105, byte.MaxValue);

		// Token: 0x040000AF RID: 175
		public static Color32 kiwidark = new Color32(72, 112, 75, byte.MaxValue);

		// Token: 0x040000B0 RID: 176
		public static Color32 OldLaceTransparent = new Color32(253, 245, 230, 80);

		// Token: 0x040000B1 RID: 177
		public static Color32 SeaShellTransparent = new Color32(byte.MaxValue, 245, 238, 80);

		// Token: 0x040000B2 RID: 178
		public static Color32 MintCreamTransparent = new Color32(245, byte.MaxValue, 250, 80);

		// Token: 0x040000B3 RID: 179
		public static Color32 BlackTransparent = new Color32(0, 0, 0, 80);

		// Token: 0x040000B4 RID: 180
		public static Color32 GreyTransparent = new Color32(80, 80, 80, 80);

		// Token: 0x040000B5 RID: 181
		public static Color32 LightGreyTransparent = new Color32(192, 192, 192, 80);

		// Token: 0x040000B6 RID: 182
		public static Color32 DarkGreyTransparent = new Color32(40, 40, 40, 80);

		// Token: 0x040000B7 RID: 183
		public static Color32 DarkerGreyTransparent = new Color32(40, 40, 40, 80);

		// Token: 0x040000B8 RID: 184
		public static Shader guiShader = Shader.Find("GUI/Text Shader");

		// Token: 0x040000B9 RID: 185
		public static Shader uberShader = Shader.Find("GorillaTag/UberShader");

		// Token: 0x040000BA RID: 186
		public static Shader uiShader = Shader.Find("UI/Default");

		// Token: 0x040000BB RID: 187
		public static Material RGB = new Material(ColorLib.uberShader);

		// Token: 0x040000BC RID: 188
		public static Material DFade = new Material(ColorLib.uberShader);

		// Token: 0x040000BD RID: 189
		public static Material DBreath = new Material(ColorLib.uberShader);

		// Token: 0x040000BE RID: 190
		public static Material BlueFade = new Material(ColorLib.uberShader);

		// Token: 0x040000BF RID: 191
		public static string hexColor = "#" + ColorUtility.ToHtmlStringRGB(ColorLib.RGB.color);

		// Token: 0x040000C0 RID: 192
		public static string hexColor1 = "#" + ColorUtility.ToHtmlStringRGB(ColorLib.DFade.color);
	}
}
