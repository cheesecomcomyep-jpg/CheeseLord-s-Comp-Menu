using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using XENONTEMP.Classes;
using XENONTEMP.Menu;

namespace XENONTEMP
{
	// Token: 0x0200000A RID: 10
	internal class Settings
	{
		// Token: 0x040000C1 RID: 193
		public static int buttonsPerPage = 4;

		// Token: 0x040000C2 RID: 194
		public static bool rightHanded = false;

		// Token: 0x040000C3 RID: 195
		public static bool righthand = false;

		// Token: 0x040000C4 RID: 196
		public static KeyCode keyboardButton = 102;

		// Token: 0x040000C5 RID: 197
		public static bool fpsCounter = true;

		// Token: 0x040000C6 RID: 198
		public static bool disconnectButton = true;

		// Token: 0x040000C7 RID: 199
		public static bool disableNotifications = false;

		// Token: 0x040000C8 RID: 200
		public static bool Ghostview = false;

		// Token: 0x040000C9 RID: 201
		public static int espSetting = 1;

		// Token: 0x040000CA RID: 202
		public static Vector3 menuSize = new Vector3(0.1f, 1.15f, 0.9f);

		// Token: 0x040000CB RID: 203
		public static Vector3 menuSize2 = new Vector3(0.1f, 1.185f, 0.5925f);

		// Token: 0x040000CC RID: 204
		public static Vector3 menuSize3 = new Vector3(0.1f, 1.185f, 0.5925f);

		// Token: 0x040000CD RID: 205
		public static ExtGradient backgroundColor = new ExtGradient
		{
			isRainbow = false
		};

		// Token: 0x040000CE RID: 206
		public static ExtGradient[] buttonColors = new ExtGradient[]
		{
			new ExtGradient
			{
				colors = Main.GetSolidGradient(new Color32(41, 41, 41, byte.MaxValue), 0f)
			},
			new ExtGradient
			{
				colors = Main.GetSolidGradient(new Color32(0, byte.MaxValue, byte.MaxValue, byte.MaxValue), 0f)
			}
		};

		// Token: 0x040000CF RID: 207
		public static Color[] textColors = new Color[]
		{
			Color.white,
			Color.white
		};

		// Token: 0x040000D0 RID: 208
		public static Color32 CurrentBackgroundColor = new Color32(121, 116, 177, byte.MaxValue);

		// Token: 0x040000D1 RID: 209
		public static Color32 OutlineColor = new Color32(0, 163, 163, byte.MaxValue);

		// Token: 0x040000D2 RID: 210
		public static Color32 OutlineColor2 = new Color32(0, 203, 173, byte.MaxValue);

		// Token: 0x040000D3 RID: 211
		public static Color MenuBG = Settings.backgroundColor.colors[0].color;

		// Token: 0x040000D4 RID: 212
		public static Font currentFont = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;

		// Token: 0x040000D5 RID: 213
		public static int currentThemeNameIndex = 0;

		// Token: 0x040000D6 RID: 214
		public static int currentBackgroundThemeIndex = 0;

		// Token: 0x040000D7 RID: 215
		public static int currentButtonThemeIndex = 0;

		// Token: 0x040000D8 RID: 216
		[TupleElementNames(new string[]
		{
			"name",
			"color"
		})]
		public static readonly ValueTuple<string, Color>[] menuBackgroundThemes = new ValueTuple<string, Color>[]
		{
			new ValueTuple<string, Color>("a", new Color32(101, 97, 148, byte.MaxValue)),
			new ValueTuple<string, Color>("b", new Color(0.13f, 0.75f, 0.47f)),
			new ValueTuple<string, Color>("c", new Color(0.023f, 0.58f, 0.145f)),
			new ValueTuple<string, Color>("d", new Color(0.98f, 0.53f, 0.22f)),
			new ValueTuple<string, Color>("e", new Color(0.56f, 0.27f, 0.68f)),
			new ValueTuple<string, Color>("f", new Color(0.91f, 0.27f, 0.47f)),
			new ValueTuple<string, Color>("g", new Color(0.98f, 0.82f, 0.22f)),
			new ValueTuple<string, Color>("h", new Color(0.36f, 0.45f, 0.51f)),
			new ValueTuple<string, Color>("i", new Color(0.53f, 0.98f, 0.82f)),
			new ValueTuple<string, Color>("j", new Color(1f, 0.49f, 0.38f)),
			new ValueTuple<string, Color>("k", new Color(0.18f, 0.22f, 0.25f)),
			new ValueTuple<string, Color>("l", new Color(0.8f, 0.07f, 0.2f)),
			new ValueTuple<string, Color>("m", new Color(0.1f, 0.2f, 0.7f)),
			new ValueTuple<string, Color>("n", new Color(1f, 0.75f, 0.2f)),
			new ValueTuple<string, Color>("o", new Color(0.13f, 0.55f, 0.13f)),
			new ValueTuple<string, Color>("p", Color.cyan),
			new ValueTuple<string, Color>("q", Color.magenta),
			new ValueTuple<string, Color>("r", new Color(1f, 1f, 0.94f)),
			new ValueTuple<string, Color>("s", new Color(0.48f, 0.25f, 0f)),
			new ValueTuple<string, Color>("t", new Color(0.5f, 0.5f, 0f)),
			new ValueTuple<string, Color>("u", new Color(0f, 0.5f, 0.5f)),
			new ValueTuple<string, Color>("v", new Color(0.9f, 0.89f, 0.89f)),
			new ValueTuple<string, Color>("w", new Color(0.29f, 0f, 0.51f)),
			new ValueTuple<string, Color>("x", new Color(0.86f, 0.08f, 0.24f)),
			new ValueTuple<string, Color>("y", new Color(0f, 0.5f, 1f)),
			new ValueTuple<string, Color>("z", new Color(0.94f, 0.92f, 0.84f)),
			new ValueTuple<string, Color>("!", new Color(0.76f, 0.7f, 0.5f)),
			new ValueTuple<string, Color>(".", new Color(0.8f, 0.5f, 0.2f)),
			new ValueTuple<string, Color>("? ", new Color(0.27f, 0.51f, 0.71f)),
			new ValueTuple<string, Color>("0", new Color(1f, 0.46f, 0.09f))
		};

		// Token: 0x040000D9 RID: 217
		[TupleElementNames(new string[]
		{
			"name",
			"color"
		})]
		public static readonly ValueTuple<string, Color>[] menuButtonThemes = new ValueTuple<string, Color>[]
		{
			new ValueTuple<string, Color>("", new Color32(121, 116, 177, byte.MaxValue)),
			new ValueTuple<string, Color>("", new Color(0.13f, 0.75f, 0.47f)),
			new ValueTuple<string, Color>("", new Color(0.98f, 0.53f, 0.22f)),
			new ValueTuple<string, Color>("", new Color(0.56f, 0.27f, 0.68f)),
			new ValueTuple<string, Color>("", new Color(0.91f, 0.27f, 0.47f)),
			new ValueTuple<string, Color>("", new Color(0.98f, 0.82f, 0.22f)),
			new ValueTuple<string, Color>("", new Color(0.36f, 0.45f, 0.51f)),
			new ValueTuple<string, Color>("", new Color(0.53f, 0.98f, 0.82f)),
			new ValueTuple<string, Color>("", new Color(1f, 0.49f, 0.38f)),
			new ValueTuple<string, Color>("", new Color(0.18f, 0.22f, 0.25f)),
			new ValueTuple<string, Color>("", new Color(0.8f, 0.07f, 0.2f)),
			new ValueTuple<string, Color>("", new Color(0.1f, 0.2f, 0.7f)),
			new ValueTuple<string, Color>("", new Color(1f, 0.75f, 0.2f)),
			new ValueTuple<string, Color>("", new Color(0.13f, 0.55f, 0.13f)),
			new ValueTuple<string, Color>("", Color.cyan),
			new ValueTuple<string, Color>("", Color.magenta),
			new ValueTuple<string, Color>("", new Color(1f, 1f, 0.94f)),
			new ValueTuple<string, Color>("", new Color(0.48f, 0.25f, 0f)),
			new ValueTuple<string, Color>("", new Color(0.5f, 0.5f, 0f)),
			new ValueTuple<string, Color>("", new Color(0f, 0.5f, 0.5f)),
			new ValueTuple<string, Color>("", new Color(0.9f, 0.89f, 0.89f)),
			new ValueTuple<string, Color>("", new Color(0.29f, 0f, 0.51f)),
			new ValueTuple<string, Color>("", new Color(0.86f, 0.08f, 0.24f)),
			new ValueTuple<string, Color>("", new Color(0f, 0.5f, 1f)),
			new ValueTuple<string, Color>("", new Color(0.94f, 0.92f, 0.84f)),
			new ValueTuple<string, Color>("", new Color(0.76f, 0.7f, 0.5f)),
			new ValueTuple<string, Color>("", new Color(0.8f, 0.5f, 0.2f)),
			new ValueTuple<string, Color>(" ", new Color(0.27f, 0.51f, 0.71f)),
			new ValueTuple<string, Color>("", new Color(1f, 0.46f, 0.09f)),
			new ValueTuple<string, Color>("", Color.black)
		};
	}
}
