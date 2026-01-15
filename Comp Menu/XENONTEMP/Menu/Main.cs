using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using BepInEx;
using Colorlib;
using GorillaLocomotion;
using HarmonyLib;
using Photon.Pun;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using XENONTEMP.Classes;
using XENONTEMP.Mods;
using XENONTEMP.Notifications;

namespace XENONTEMP.Menu
{
	// Token: 0x02000020 RID: 32
	[HarmonyPatch(typeof(GTPlayer))]
	[HarmonyPatch("LateUpdate", 0)]
	public class Main : MonoBehaviour
	{
		// Token: 0x0600008F RID: 143 RVA: 0x00006516 File Offset: 0x00004716
		public static void CustomNameTag()
		{
			PhotonNetwork.LocalPlayer.NickName = "<color=purple>" + PhotonNetwork.LocalPlayer.NickName + "</color>";
		}

		// Token: 0x06000090 RID: 144 RVA: 0x0000653D File Offset: 0x0000473D
		public static void PlayBackGroundMusic()
		{
			GorillaTagger.Instance.StartCoroutine(Main.PlaySFX(Main.BackGroundMusic));
		}

		// Token: 0x06000091 RID: 145 RVA: 0x00006558 File Offset: 0x00004758
		public static void Prefix()
		{
			Main.bgMat.color = new Color32(byte.MaxValue, 215, 0, byte.MaxValue);
			bool flag = Main.buttonsType == 13;
			if (flag)
			{
				List<ButtonInfo> list = new List<ButtonInfo>();
				int num = 0;
				foreach (ButtonInfo[] array in Buttons.buttons)
				{
					foreach (ButtonInfo buttonInfo in array)
					{
						bool enabled = buttonInfo.enabled;
						if (enabled)
						{
							list.Add(buttonInfo);
						}
					}
					num++;
				}
			}
			bool flag2 = Main.boardshit;
			if (flag2)
			{
				Main.UpdateStumpBoards();
			}
			bool flag3 = !Directory.Exists("Xenon");
			if (flag3)
			{
				Directory.CreateDirectory("Xenon");
			}
			try
			{
				Main.HandleMenuToggle();
			}
			catch (Exception ex)
			{
				Debug.LogError("Comp // Error initializing at " + ex.StackTrace + ": " + ex.Message);
			}
			try
			{
				Main.UpdateFPSCounter();
				Main.RunEnabledMods();
			}
			catch (Exception ex2)
			{
				Debug.LogError("Comp // Error with executing mods at " + ex2.StackTrace + ": " + ex2.Message);
			}
		}

		// Token: 0x06000092 RID: 146 RVA: 0x000066BC File Offset: 0x000048BC
		private static void HandleMenuToggle()
		{
			bool flag = (!Settings.rightHanded && ControllerInputPoller.instance.leftControllerSecondaryButton) || (Settings.rightHanded && ControllerInputPoller.instance.rightControllerSecondaryButton);
			bool key = UnityInput.Current.GetKey(Settings.keyboardButton);
			bool flag2 = Main.menu == null;
			if (flag2)
			{
				bool flag3 = flag || key;
				if (flag3)
				{
					Main.CreateMenu();
					Main.RecenterMenu(Settings.rightHanded, key);
					GorillaTagger.Instance.StartCoroutine(Main.OpenAni());
					bool ani = Main.Ani4;
					if (ani)
					{
						GorillaTagger.Instance.StartCoroutine(Main.WobbleOpenAni());
					}
					bool flag4 = Main.reference == null;
					if (flag4)
					{
						Main.CreateReference(Settings.rightHanded);
					}
				}
			}
			else
			{
				bool flag5 = flag || key;
				if (flag5)
				{
					Main.RecenterMenu(Settings.rightHanded, key);
				}
				else
				{
					GameObject.Find("Shoulder Camera").transform.Find("CM vcam1").gameObject.SetActive(true);
					GorillaTagger.Instance.StartCoroutine(Main.CloseAni());
					bool ani2 = Main.Ani4;
					if (ani2)
					{
						GorillaTagger.Instance.StartCoroutine(Main.WobbleCloseAni());
					}
				}
			}
		}

		// Token: 0x06000093 RID: 147 RVA: 0x000067F4 File Offset: 0x000049F4
		private static void UpdateStumpBoards()
		{
			try
			{
				string text = "<color=blue>C</color><color=red>o</color><color=green>m</color><color=yellow>p</color>";
				string text2 = "<color=#612816><b>Goofy Goober Bean.</b></color>";
				GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/motdHeadingText").GetComponent<TextMeshPro>().text = "Cheese's " + text + " Menu";
				GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/motdBodyText").GetComponent<TextMeshPro>().text = string.Concat(new string[]
				{
					"\nCheese's ",
					text,
					" Menu\nThe mehest ",
					text,
					" menu.\nFollow the rules, or not. just dont get banned, no one likes being banned, not my fault if u get banned. ",
					text2
				});
				GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/CodeOfConductHeadingText").GetComponent<TextMeshPro>().text = "Cheese's " + text + " Menu \n----------------------------- \n";
				GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/COCBodyText_TitleData").GetComponent<TextMeshPro>().text = "Made by Cheeselord\n Eat Cheese, and buy the astre menu, I get 200 robux out of 500, i get money, buy it.";
				GameObject gameObject = GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomBoundaryStones/BoundaryStoneSet_Forest/wallmonitorforestbg");
				bool flag = gameObject != null;
				if (flag)
				{
					Renderer component = gameObject.GetComponent<Renderer>();
					bool flag2 = component != null;
					if (flag2)
					{
						component.material = Main.bgMat;
					}
				}
				GameObject gameObject2 = GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/GorillaComputerObject/ComputerUI/monitor/monitorScreen");
				bool flag3 = gameObject2 != null;
				if (flag3)
				{
					Renderer component2 = gameObject2.GetComponent<Renderer>();
					bool flag4 = component2 != null;
					if (flag4)
					{
						component2.material = Main.bgMat;
					}
				}
				Main.UpdateLeaderboard("Environment Objects/LocalObjects_Prefab/TreeRoom", Main.StumpLeaderboardID, Main.StumpLeaderboardIndex, ref Main.StumpMat);
				Main.UpdateLeaderboard("Environment Objects/LocalObjects_Prefab/Forest", Main.ForestLeaderboardID, Main.ForestLeaderboardIndex, ref Main.ForestMat);
				bool inRoom = PhotonNetwork.InRoom;
				if (inRoom)
				{
					GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/motdBodyText").GetComponent<TextMeshPro>().text = "This comp menu is made by CheeseLord";
					Main.boardshit = false;
				}
			}
			catch (Exception ex)
			{
				Debug.LogError("Error updating Stump: " + ex.Message);
			}
		}

		// Token: 0x06000094 RID: 148 RVA: 0x000069D4 File Offset: 0x00004BD4
		private static void UpdateLeaderboard(string parentPath, string leaderboardID, int targetIndex, ref Material matRef)
		{
			GameObject gameObject = GameObject.Find(parentPath);
			bool flag = gameObject == null;
			if (!flag)
			{
				int num = 0;
				for (int i = 0; i < gameObject.transform.childCount; i++)
				{
					GameObject gameObject2 = gameObject.transform.GetChild(i).gameObject;
					bool flag2 = gameObject2.name.Contains(leaderboardID);
					if (flag2)
					{
						num++;
						bool flag3 = num == targetIndex;
						if (flag3)
						{
							bool flag4 = matRef == null;
							if (flag4)
							{
								matRef = gameObject2.GetComponent<Renderer>().material;
							}
							gameObject2.GetComponent<Renderer>().material = Main.bgMat;
							break;
						}
					}
				}
			}
		}

		// Token: 0x06000095 RID: 149 RVA: 0x00006A8C File Offset: 0x00004C8C
		private static void UpdateFPSCounter()
		{
			bool flag = Main.fpsObject != null;
			if (flag)
			{
				Main.fpsObject.text = "FPS: " + Mathf.Ceil(1f / Time.unscaledDeltaTime).ToString();
			}
		}

		// Token: 0x06000096 RID: 150 RVA: 0x00006AD8 File Offset: 0x00004CD8
		private static void RunEnabledMods()
		{
			foreach (ButtonInfo[] array in Buttons.buttons)
			{
				foreach (ButtonInfo buttonInfo in array)
				{
					bool flag = buttonInfo.enabled && buttonInfo.method != null;
					if (flag)
					{
						try
						{
							buttonInfo.method.Invoke();
						}
						catch (Exception ex)
						{
							Debug.LogError(string.Concat(new string[]
							{
								"Comp // Error with mod ",
								buttonInfo.buttonText,
								" at ",
								ex.StackTrace,
								": ",
								ex.Message
							}));
						}
					}
				}
			}
		}

		// Token: 0x06000097 RID: 151 RVA: 0x00006BB8 File Offset: 0x00004DB8
		public static void CreateMenu()
		{
			Main.menu = GameObject.CreatePrimitive(3);
			Object.Destroy(Main.menu.GetComponent<Rigidbody>());
			Object.Destroy(Main.menu.GetComponent<BoxCollider>());
			Object.Destroy(Main.menu.GetComponent<Renderer>());
			Main.menu.transform.localScale = new Vector3(0.1f, 0.3f, 0.3825f);
			Main.CreateMenuBackground();
			Main.CreateCanvas();
			Main.CreateTitleAndFPS();
			Main.CreateNavigationButtons();
			Main.CreateModButtons();
		}

		// Token: 0x06000098 RID: 152 RVA: 0x00006C44 File Offset: 0x00004E44
		private static void CreateMenuBackground()
		{
			Main.menuBackground = GameObject.CreatePrimitive(3);
			Object.Destroy(Main.menuBackground.GetComponent<Rigidbody>());
			Object.Destroy(Main.menuBackground.GetComponent<BoxCollider>());
			Main.menuBackground.transform.parent = Main.menu.transform;
			Main.menuBackground.transform.rotation = Quaternion.identity;
			Main.menuBackground.transform.localScale = Settings.menuSize;
			Main.menuBackground.transform.position = new Vector3(0.05f, 0f, 0f);
			Main.menuBackground.GetComponent<Renderer>().material.color = new Color(0.39607844f, 0.61960787f, 0.4117647f, 1f);
			Main.menuBackground.GetComponent<Renderer>().enabled = false;
			float bevel = Main.noround ? 0f : 0.075f;
			Main.CreateRoundedRectangleParts(Main.menuBackground.transform.localPosition, Settings.menuSize, new Color32(25, 25, 25, byte.MaxValue), bevel);
			ColorChanger colorChanger = Main.menuBackground.AddComponent<ColorChanger>();
			colorChanger.colorInfo = Settings.backgroundColor;
			colorChanger.Start();
			bool outlineint = Main.Outlineint;
			if (outlineint)
			{
				Main.CreateMenuOutline();
				Main.CreateMenuOutline2();
			}
		}

		// Token: 0x06000099 RID: 153 RVA: 0x00006D98 File Offset: 0x00004F98
		private static void CreateMenuOutline()
		{
			Main.menu2 = GameObject.CreatePrimitive(3);
			Object.Destroy(Main.menu2.GetComponent<Rigidbody>());
			Object.Destroy(Main.menu2.GetComponent<BoxCollider>());
			Object.Destroy(Main.menu2.GetComponent<Renderer>());
			Main.menu2.transform.localScale = new Vector3(0.1f, 0.3f, 0.3825f);
			Main.menuBackground2 = GameObject.CreatePrimitive(3);
			Object.Destroy(Main.menuBackground2.GetComponent<Rigidbody>());
			Object.Destroy(Main.menuBackground2.GetComponent<BoxCollider>());
			Main.menuBackground2.transform.parent = Main.menu2.transform;
			Main.menuBackground2.transform.rotation = Quaternion.identity;
			Main.menuBackground2.transform.localScale = Settings.menuSize2;
			Main.menuBackground2.transform.position = new Vector3(0.047f, 0f, 0.065f);
			Main.menuBackground2.GetComponent<Renderer>().material.color = Settings.OutlineColor;
			Main.menuBackground2.GetComponent<Renderer>().enabled = false;
			float bevel = Main.noround ? 0f : 0.075f;
			Main.CreateRoundedRectangleParts(Main.menuBackground2.transform.localPosition, Settings.menuSize2, Settings.OutlineColor, bevel);
		}

		// Token: 0x0600009A RID: 154 RVA: 0x00006EFC File Offset: 0x000050FC
		private static void CreateMenuOutline2()
		{
			Main.menu2 = GameObject.CreatePrimitive(3);
			Object.Destroy(Main.menu2.GetComponent<Rigidbody>());
			Object.Destroy(Main.menu2.GetComponent<BoxCollider>());
			Object.Destroy(Main.menu2.GetComponent<Renderer>());
			Main.menu2.transform.localScale = new Vector3(0.1f, 0.3f, 0.3825f);
			Main.menuBackground2 = GameObject.CreatePrimitive(3);
			Object.Destroy(Main.menuBackground2.GetComponent<Rigidbody>());
			Object.Destroy(Main.menuBackground2.GetComponent<BoxCollider>());
			Main.menuBackground2.transform.parent = Main.menu2.transform;
			Main.menuBackground2.transform.rotation = Quaternion.identity;
			Main.menuBackground2.transform.localScale = Settings.menuSize3;
			Main.menuBackground2.transform.position = new Vector3(0.047f, 0f, -0.065f);
			Main.menuBackground2.GetComponent<Renderer>().material.color = Settings.OutlineColor2;
			Main.menuBackground2.GetComponent<Renderer>().enabled = false;
			float bevel = Main.noround ? 0f : 0.075f;
			Main.CreateRoundedRectangleParts(Main.menuBackground2.transform.localPosition, Settings.menuSize2, Settings.OutlineColor2, bevel);
		}

		// Token: 0x0600009B RID: 155 RVA: 0x00007060 File Offset: 0x00005260
		private static void CreateCanvas()
		{
			Main.canvasObject = new GameObject();
			Main.canvasObject.transform.parent = Main.menu.transform;
			Canvas canvas = Main.canvasObject.AddComponent<Canvas>();
			CanvasScaler canvasScaler = Main.canvasObject.AddComponent<CanvasScaler>();
			Main.canvasObject.AddComponent<GraphicRaycaster>();
			canvas.renderMode = 2;
			canvasScaler.dynamicPixelsPerUnit = 5000f;
		}

		// Token: 0x0600009C RID: 156 RVA: 0x000070C8 File Offset: 0x000052C8
		private static void CreateTitleAndFPS()
		{
			Text text = new GameObject
			{
				transform = 
				{
					parent = Main.canvasObject.transform
				}
			}.AddComponent<Text>();
			text.font = Settings.currentFont;
			bool flag = Main.shouldAnimate;
			if (flag)
			{
				text.text = "";
				GorillaTagger.Instance.StartCoroutine(Main.AnimateTitle(text));
			}
			else
			{
				text.text = "Comp";
			}
			text.fontSize = 1;
			text.color = Settings.textColors[0];
			text.supportRichText = true;
			text.fontStyle = 0;
			text.alignment = 4;
			text.resizeTextForBestFit = true;
			text.resizeTextMinSize = 0;
			RectTransform component = text.GetComponent<RectTransform>();
			component.localPosition = Vector3.zero;
			component.sizeDelta = new Vector2(0.28f, 0.06f);
			component.position = new Vector3(0.06f, 0f, 0.09f);
			bool fpsCounter = Settings.fpsCounter;
			if (fpsCounter)
			{
				component.position = new Vector3(0.06f, 0f, 0.1086f);
			}
			component.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
			bool fpsCounter2 = Settings.fpsCounter;
			if (fpsCounter2)
			{
				Main.fpsObject = new GameObject
				{
					transform = 
					{
						parent = Main.canvasObject.transform
					}
				}.AddComponent<Text>();
				Main.fpsObject.font = Settings.currentFont;
				Main.fpsObject.text = "FPS: " + Mathf.Ceil(1f / Time.unscaledDeltaTime).ToString();
				Main.fpsObject.color = Settings.textColors[0];
				Main.fpsObject.fontSize = 1;
				Main.fpsObject.supportRichText = true;
				Main.fpsObject.fontStyle = 0;
				Main.fpsObject.alignment = 4;
				Main.fpsObject.horizontalOverflow = 1;
				Main.fpsObject.resizeTextForBestFit = true;
				Main.fpsObject.resizeTextMinSize = 0;
				RectTransform component2 = Main.fpsObject.GetComponent<RectTransform>();
				component2.localPosition = Vector3.zero;
				component2.sizeDelta = new Vector2(0.28f, 0.025f);
				component2.position = new Vector3(0.06f, 0f, 0.064f);
				component2.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
			}
		}

		// Token: 0x0600009D RID: 157 RVA: 0x00007354 File Offset: 0x00005554
		private static void CreateNavigationButtons()
		{
			bool disconnectButton = Settings.disconnectButton;
			if (disconnectButton)
			{
				Main.CreateDisconnectButton();
			}
			bool flag = Main.buttonsType > 0;
			if (flag)
			{
				Main.CreateHomeButton();
			}
			bool flag2 = Main.shouldPrev;
			if (flag2)
			{
				Main.CreatePreviousPageButton();
			}
			bool flag3 = Main.shouldNext;
			if (flag3)
			{
				Main.CreateNextPageButton();
			}
			bool flag4 = Main.shouldConfig;
			if (flag4)
			{
				Main.CreateConfigButton();
			}
		}

		// Token: 0x0600009E RID: 158 RVA: 0x000073BC File Offset: 0x000055BC
		private static void CreateDisconnectButton()
		{
			Vector3 position;
			position..ctor(0.6f, -0.55f, 0.285f);
			Vector3 scale;
			scale..ctor(0.09f, 0.07f, 0.07f);
			GameObject gameObject = Main.CreateButtonWithRoundedCorners(position, scale, new Color32(41, 41, 41, byte.MaxValue));
			gameObject.AddComponent<Button>().relatedText = "Disconnect";
			ColorChanger colorChanger = gameObject.AddComponent<ColorChanger>();
			colorChanger.colorInfo = Settings.buttonColors[0];
			colorChanger.Start();
			bool outlineint = Main.Outlineint;
			if (outlineint)
			{
				Main.CreateButtonOutline(position, new Vector3(0.089f, 0.11f, 0.09f), Settings.OutlineColor);
			}
		}

		// Token: 0x0600009F RID: 159 RVA: 0x00007468 File Offset: 0x00005668
		private static void CreateHomeButton()
		{
			Vector3 position;
			position..ctor(0.56f, 0f, -0.32f);
			Vector3 scale;
			scale..ctor(0.09f, 0.2f, 0.1f);
			GameObject gameObject = Main.CreateButtonWithRoundedCorners(position, scale, new Color32(41, 41, 41, byte.MaxValue));
			gameObject.AddComponent<Button>().relatedText = "Home3";
			ColorChanger colorChanger = gameObject.AddComponent<ColorChanger>();
			colorChanger.colorInfo = Settings.buttonColors[0];
			colorChanger.Start();
			bool outlineint = Main.Outlineint;
			if (outlineint)
			{
				Main.CreateButtonOutline(new Vector3(0.54f, 0f, -0.32f), new Vector3(0.089f, 0.22f, 0.12f), Settings.OutlineColor);
			}
		}

		// Token: 0x060000A0 RID: 160 RVA: 0x00007528 File Offset: 0x00005728
		private static void CreatePreviousPageButton()
		{
			Vector3 position;
			position..ctor(0.6f, 0.27f, -0.32f);
			Vector3 scale;
			scale..ctor(0.09f, 0.15f, 0.07f);
			GameObject gameObject = Main.CreateButtonWithRoundedCorners(position, scale, new Color32(45, 113, 192, byte.MaxValue));
			gameObject.AddComponent<Button>().relatedText = "PreviousPage";
			ColorChanger colorChanger = gameObject.AddComponent<ColorChanger>();
			colorChanger.colorInfo = Settings.buttonColors[0];
			colorChanger.Start();
			bool outlineint = Main.Outlineint;
			if (outlineint)
			{
				Main.CreateButtonOutline(position, new Vector3(0.089f, 0.17f, 0.09f), new Color32(25, 93, 172, byte.MaxValue));
			}
			Main.CreateButtonText("<", new Vector3(0.07f, 0.083f, -0.1199f));
		}

		// Token: 0x060000A1 RID: 161 RVA: 0x00007604 File Offset: 0x00005804
		private static void CreateNextPageButton()
		{
			Vector3 position;
			position..ctor(0.6f, -0.27f, -0.32f);
			Vector3 scale;
			scale..ctor(0.09f, 0.15f, 0.07f);
			GameObject gameObject = Main.CreateButtonWithRoundedCorners(position, scale, new Color32(45, 113, 192, byte.MaxValue));
			gameObject.AddComponent<Button>().relatedText = "NextPage";
			ColorChanger colorChanger = gameObject.AddComponent<ColorChanger>();
			colorChanger.colorInfo = Settings.buttonColors[0];
			colorChanger.Start();
			bool outlineint = Main.Outlineint;
			if (outlineint)
			{
				Main.CreateButtonOutline(position, new Vector3(0.089f, 0.17f, 0.09f), new Color32(25, 93, 172, byte.MaxValue));
			}
			Main.CreateButtonText(">", new Vector3(0.07f, -0.083f, -0.1199f));
		}

		// Token: 0x060000A2 RID: 162 RVA: 0x000076E0 File Offset: 0x000058E0
		private static void CreateConfigButton()
		{
			Vector3 position;
			position..ctor(0.6f, -0.55f, 0.38f);
			Vector3 scale;
			scale..ctor(0.09f, 0.07f, 0.07f);
			GameObject gameObject = Main.CreateButtonWithRoundedCorners(position, scale, new Color32(45, 45, 45, byte.MaxValue));
			gameObject.AddComponent<Button>().relatedText = "Config";
			ColorChanger colorChanger = gameObject.AddComponent<ColorChanger>();
			colorChanger.colorInfo = Settings.buttonColors[0];
			colorChanger.Start();
			bool outlineint = Main.Outlineint;
			if (outlineint)
			{
				Main.CreateButtonOutline(position, new Vector3(0.089f, 0.11f, 0.09f), Settings.OutlineColor);
			}
		}

		// Token: 0x060000A3 RID: 163 RVA: 0x0000778C File Offset: 0x0000598C
		private static void CreateModButtons()
		{
			ButtonInfo[] array = Enumerable.ToArray<ButtonInfo>(Enumerable.Take<ButtonInfo>(Enumerable.Skip<ButtonInfo>(Buttons.buttons[Main.buttonsType], Main.pageNumber * 4), 4));
			for (int i = 0; i < array.Length; i++)
			{
				Main.CreateButton((float)i * 0.09f, array[i]);
			}
		}

		// Token: 0x060000A4 RID: 164 RVA: 0x000077E4 File Offset: 0x000059E4
		public static void CreateButton(float offset, ButtonInfo method)
		{
			Vector3 position;
			position..ctor(0.56f, -0.32f, 0.1f - offset);
			Vector3 scale;
			scale..ctor(0.1f, 0.1f, 0.0825f);
			Color32 color = method.enabled ? new Color32(0, byte.MaxValue, byte.MaxValue, byte.MaxValue) : new Color32(45, 45, 45, byte.MaxValue);
			GameObject gameObject = Main.CreateButtonWithRoundedCorners(position, scale, color);
			gameObject.AddComponent<Button>().relatedText = method.buttonText;
			ColorChanger colorChanger = gameObject.AddComponent<ColorChanger>();
			colorChanger.colorInfo = (method.enabled ? Settings.buttonColors[1] : Settings.buttonColors[0]);
			colorChanger.Start();
			Text text = new GameObject
			{
				transform = 
				{
					parent = Main.canvasObject.transform
				}
			}.AddComponent<Text>();
			text.font = Settings.currentFont;
			text.text = (method.overlapText ?? method.buttonText);
			text.supportRichText = true;
			text.fontSize = 1;
			text.color = (method.enabled ? Settings.textColors[1] : Settings.textColors[0]);
			text.alignment = 3;
			text.fontStyle = 0;
			text.resizeTextForBestFit = true;
			text.resizeTextMinSize = 0;
			RectTransform component = text.GetComponent<RectTransform>();
			component.localPosition = Vector3.zero;
			component.sizeDelta = new Vector2(0.15f, 0.02f);
			component.localPosition = new Vector3(0.064f, 0.032f, 0.039f - offset / 2.6f);
			component.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
		}

		// Token: 0x060000A5 RID: 165 RVA: 0x000079B0 File Offset: 0x00005BB0
		private static GameObject CreateButtonWithRoundedCorners(Vector3 position, Vector3 scale, Color32 color)
		{
			GameObject gameObject = GameObject.CreatePrimitive(3);
			bool flag = !UnityInput.Current.GetKey(102);
			if (flag)
			{
				gameObject.layer = 2;
			}
			Object.Destroy(gameObject.GetComponent<Rigidbody>());
			gameObject.GetComponent<BoxCollider>().isTrigger = true;
			gameObject.transform.parent = Main.menu.transform;
			gameObject.transform.rotation = Quaternion.identity;
			gameObject.transform.localScale = scale;
			gameObject.transform.localPosition = position;
			gameObject.GetComponent<Renderer>().enabled = false;
			Main.CreateRoundedRectangleParts(position, scale, color, 0.03f);
			return gameObject;
		}

		// Token: 0x060000A6 RID: 166 RVA: 0x00007A5C File Offset: 0x00005C5C
		private static void CreateRoundedRectangleParts(Vector3 position, Vector3 scale, Color32 color, float bevel)
		{
			GameObject gameObject = GameObject.CreatePrimitive(3);
			gameObject.GetComponent<Renderer>().enabled = true;
			Object.Destroy(gameObject.GetComponent<Collider>());
			gameObject.transform.parent = Main.menu.transform;
			gameObject.transform.rotation = Quaternion.identity;
			gameObject.transform.localPosition = position;
			gameObject.transform.localScale = scale + new Vector3(0f, bevel * -2.55f, 0f);
			gameObject.GetComponent<Renderer>().material.color = color;
			GameObject gameObject2 = GameObject.CreatePrimitive(3);
			gameObject2.GetComponent<Renderer>().enabled = true;
			Object.Destroy(gameObject2.GetComponent<Collider>());
			gameObject2.transform.parent = Main.menu.transform;
			gameObject2.transform.rotation = Quaternion.identity;
			gameObject2.transform.localPosition = position;
			gameObject2.transform.localScale = scale + new Vector3(0f, 0f, -bevel * 2f);
			gameObject2.GetComponent<Renderer>().material.color = color;
			Main.CreateCornerCylinder(position, scale, bevel, color, 1, 1);
			Main.CreateCornerCylinder(position, scale, bevel, color, -1, 1);
			Main.CreateCornerCylinder(position, scale, bevel, color, 1, -1);
			Main.CreateCornerCylinder(position, scale, bevel, color, -1, -1);
		}

		// Token: 0x060000A7 RID: 167 RVA: 0x00007BC4 File Offset: 0x00005DC4
		private static void CreateCornerCylinder(Vector3 basePosition, Vector3 scale, float bevel, Color32 color, int yDir, int zDir)
		{
			GameObject gameObject = GameObject.CreatePrimitive(2);
			gameObject.GetComponent<Renderer>().enabled = true;
			Object.Destroy(gameObject.GetComponent<Collider>());
			gameObject.transform.parent = Main.menu.transform;
			gameObject.transform.rotation = Quaternion.Euler(0f, 0f, 90f);
			Vector3 localPosition = basePosition + new Vector3(0f, (scale.y / 2f - bevel * 1.275f) * (float)yDir, (scale.z / 2f - bevel) * (float)zDir);
			gameObject.transform.localPosition = localPosition;
			gameObject.transform.localScale = new Vector3(bevel * 2.55f, scale.x / 2f, bevel * 2f);
			gameObject.GetComponent<Renderer>().material.color = color;
		}

		// Token: 0x060000A8 RID: 168 RVA: 0x00007CB2 File Offset: 0x00005EB2
		private static void CreateButtonOutline(Vector3 position, Vector3 scale, Color32 color)
		{
			Main.CreateRoundedRectangleParts(position, scale, color, 0.03f);
		}

		// Token: 0x060000A9 RID: 169 RVA: 0x00007CC4 File Offset: 0x00005EC4
		private static void CreateButtonText(string text, Vector3 position)
		{
			Text text2 = new GameObject
			{
				transform = 
				{
					parent = Main.canvasObject.transform
				}
			}.AddComponent<Text>();
			text2.font = Settings.currentFont;
			text2.text = text;
			text2.fontSize = 1;
			text2.color = Settings.textColors[0];
			text2.alignment = 4;
			text2.resizeTextForBestFit = true;
			text2.resizeTextMinSize = 0;
			RectTransform component = text2.GetComponent<RectTransform>();
			component.localPosition = Vector3.zero;
			component.sizeDelta = new Vector2(0.2f, 0.03f);
			component.localPosition = position;
			component.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
		}

		// Token: 0x060000AA RID: 170 RVA: 0x00007D8C File Offset: 0x00005F8C
		private static void CreateIcon(string resourceName, ref Texture2D icon, ref Material mat, Vector3 position, Vector2 size)
		{
			Image image = new GameObject
			{
				transform = 
				{
					parent = Main.canvasObject.transform
				}
			}.AddComponent<Image>();
			bool flag = icon == null;
			if (flag)
			{
				icon = Main.LoadTextureFromResource(resourceName);
			}
			bool flag2 = mat == null;
			if (flag2)
			{
				mat = new Material(image.material);
			}
			image.material = mat;
			image.material.SetTexture("_MainTex", icon);
			RectTransform component = image.GetComponent<RectTransform>();
			component.localPosition = Vector3.zero;
			component.sizeDelta = size;
			component.localPosition = position;
			component.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
		}

		// Token: 0x060000AB RID: 171 RVA: 0x00007E4C File Offset: 0x0000604C
		public static void OutlineObj(GameObject obj, Color clr)
		{
			GameObject gameObject = GameObject.CreatePrimitive(3);
			Object.Destroy(gameObject.GetComponent<Rigidbody>());
			Object.Destroy(gameObject.GetComponent<BoxCollider>());
			gameObject.transform.parent = obj.transform;
			gameObject.transform.rotation = Quaternion.identity;
			gameObject.transform.localPosition = obj.transform.localPosition;
			gameObject.transform.localScale = obj.transform.localScale + new Vector3(-0.025f, 0.0125f, 0.005f);
			gameObject.GetComponent<Renderer>().material.color = ColorLib.kiwidark;
		}

		// Token: 0x060000AC RID: 172 RVA: 0x00007EFE File Offset: 0x000060FE
		public static IEnumerator OpenAni()
		{
			return new Main.<OpenAni>d__88(0);
		}

		// Token: 0x060000AD RID: 173 RVA: 0x00007F06 File Offset: 0x00006106
		public static IEnumerator CloseAni()
		{
			return new Main.<CloseAni>d__89(0);
		}

		// Token: 0x060000AE RID: 174 RVA: 0x00007F0E File Offset: 0x0000610E
		public static IEnumerator WobbleOpenAni()
		{
			return new Main.<WobbleOpenAni>d__90(0);
		}

		// Token: 0x060000AF RID: 175 RVA: 0x00007F16 File Offset: 0x00006116
		public static IEnumerator WobbleCloseAni()
		{
			return new Main.<WobbleCloseAni>d__91(0);
		}

		// Token: 0x060000B0 RID: 176 RVA: 0x00007F1E File Offset: 0x0000611E
		public static IEnumerator ElasticOpenAni()
		{
			return new Main.<ElasticOpenAni>d__92(0);
		}

		// Token: 0x060000B1 RID: 177 RVA: 0x00007F26 File Offset: 0x00006126
		public static IEnumerator ElasticCloseAni()
		{
			return new Main.<ElasticCloseAni>d__93(0);
		}

		// Token: 0x060000B2 RID: 178 RVA: 0x00007F2E File Offset: 0x0000612E
		private static IEnumerator AnimateTitle(Text text)
		{
			Main.<AnimateTitle>d__94 <AnimateTitle>d__ = new Main.<AnimateTitle>d__94(0);
			<AnimateTitle>d__.text = text;
			return <AnimateTitle>d__;
		}

		// Token: 0x060000B3 RID: 179 RVA: 0x00007F3D File Offset: 0x0000613D
		public static IEnumerator PlaySFX(string url)
		{
			Main.<PlaySFX>d__95 <PlaySFX>d__ = new Main.<PlaySFX>d__95(0);
			<PlaySFX>d__.url = url;
			return <PlaySFX>d__;
		}

		// Token: 0x060000B4 RID: 180 RVA: 0x00007F4C File Offset: 0x0000614C
		public static void RecreateMenu()
		{
			bool flag = Main.menu != null;
			if (flag)
			{
				Object.Destroy(Main.menu);
				Main.menu = null;
				Main.CreateMenu();
				Main.RecenterMenu(Settings.rightHanded, UnityInput.Current.GetKey(Settings.keyboardButton));
			}
		}

		// Token: 0x060000B5 RID: 181 RVA: 0x00007F9C File Offset: 0x0000619C
		public static void RecenterMenu(bool isRightHanded, bool isKeyboardCondition)
		{
			bool flag = !isKeyboardCondition;
			if (flag)
			{
				bool flag2 = !isRightHanded;
				if (flag2)
				{
					Main.menu.transform.position = GorillaTagger.Instance.leftHandTransform.position;
					Main.menu.transform.rotation = GorillaTagger.Instance.leftHandTransform.rotation;
				}
				else
				{
					Main.menu.transform.position = GorillaTagger.Instance.rightHandTransform.position;
					Vector3 vector = GorillaTagger.Instance.rightHandTransform.rotation.eulerAngles;
					vector += new Vector3(0f, 0f, 180f);
					Main.menu.transform.rotation = Quaternion.Euler(vector);
				}
			}
			else
			{
				try
				{
					Main.TPC = GameObject.Find("Player Objects/Third Person Camera/Shoulder Camera").GetComponent<Camera>();
				}
				catch
				{
				}
				GameObject.Find("Shoulder Camera").transform.Find("CM vcam1").gameObject.SetActive(false);
				bool flag3 = Main.TPC != null;
				if (flag3)
				{
					Main.TPC.transform.position = new Vector3(-999f, -999f, -999f);
					Main.TPC.transform.rotation = Quaternion.identity;
					Main.menu.transform.parent = Main.TPC.transform;
					Main.menu.transform.position = Main.TPC.transform.position + Vector3.Scale(Main.TPC.transform.forward, new Vector3(0.5f, 0.5f, 0.5f)) + Vector3.Scale(Main.TPC.transform.up, new Vector3(-0.02f, -0.02f, -0.02f));
					Vector3 eulerAngles = Main.TPC.transform.rotation.eulerAngles;
					eulerAngles..ctor(eulerAngles.x - 90f, eulerAngles.y + 90f, eulerAngles.z);
					Main.menu.transform.rotation = Quaternion.Euler(eulerAngles);
					bool flag4 = Main.reference != null;
					if (flag4)
					{
						bool isPressed = Mouse.current.leftButton.isPressed;
						if (isPressed)
						{
							Ray ray = Main.TPC.ScreenPointToRay(Mouse.current.position.ReadValue());
							RaycastHit raycastHit;
							bool flag5 = Physics.Raycast(ray, ref raycastHit, 100f);
							bool flag6 = flag5;
							if (flag6)
							{
								Button component = raycastHit.transform.gameObject.GetComponent<Button>();
								bool flag7 = component != null;
								if (flag7)
								{
									component.OnTriggerEnter(Main.buttonCollider);
								}
							}
						}
						else
						{
							Main.reference.transform.position = new Vector3(999f, -999f, -999f);
						}
					}
				}
			}
		}

		// Token: 0x060000B6 RID: 182 RVA: 0x000082C0 File Offset: 0x000064C0
		public static void CreateReference(bool isRightHanded)
		{
			Main.reference = GameObject.CreatePrimitive(0);
			if (isRightHanded)
			{
				Main.reference.transform.parent = GorillaTagger.Instance.leftHandTransform;
			}
			else
			{
				Main.reference.transform.parent = GorillaTagger.Instance.rightHandTransform;
			}
			Main.reference.GetComponent<Renderer>().material.color = Settings.backgroundColor.colors[0].color;
			Main.reference.transform.localPosition = new Vector3(0f, -0.1f, 0f);
			Main.reference.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
			Main.buttonCollider = Main.reference.GetComponent<SphereCollider>();
			ColorChanger colorChanger = Main.reference.AddComponent<ColorChanger>();
			colorChanger.colorInfo = Settings.backgroundColor;
			colorChanger.Start();
		}

		// Token: 0x060000B7 RID: 183 RVA: 0x000083B8 File Offset: 0x000065B8
		public static void Toggle(string buttonText)
		{
			int num = (Buttons.buttons[Main.buttonsType].Length + 4 - 1) / 4 - 1;
			bool flag = buttonText == "PreviousPage";
			if (flag)
			{
				Main.pageNumber--;
				bool flag2 = Main.pageNumber < 0;
				if (flag2)
				{
					Main.pageNumber = num;
				}
			}
			else
			{
				bool flag3 = buttonText == "Config";
				if (flag3)
				{
					SettingsMods.EnterSettings();
				}
				else
				{
					bool flag4 = buttonText == "Panic";
					if (flag4)
					{
						foreach (ButtonInfo[] array in Buttons.buttons)
						{
							foreach (ButtonInfo buttonInfo in array)
							{
								bool enabled = buttonInfo.enabled;
								if (enabled)
								{
									buttonInfo.enabled = false;
								}
							}
						}
					}
					else
					{
						bool flag5 = buttonText == "NextPage";
						if (flag5)
						{
							Main.pageNumber++;
							bool flag6 = Main.pageNumber > num;
							if (flag6)
							{
								Main.pageNumber = 0;
							}
						}
						else
						{
							bool flag7 = buttonText == "Home";
							if (flag7)
							{
								Global.ReturnHome();
							}
							else
							{
								ButtonInfo index = Main.GetIndex(buttonText);
								bool flag8 = index != null;
								if (flag8)
								{
									bool isTogglable = index.isTogglable;
									if (isTogglable)
									{
										index.enabled = !index.enabled;
										bool enabled2 = index.enabled;
										if (enabled2)
										{
											bool flag9 = index.enableMethod != null;
											if (flag9)
											{
												NotifiLib.SendNotification("[<color=grey>Xe</color><color=cyan>non</color>]: " + index.toolTip);
												try
												{
													index.enableMethod.Invoke();
												}
												catch
												{
												}
											}
										}
										else
										{
											bool flag10 = index.disableMethod != null;
											if (flag10)
											{
												NotifiLib.SendNotification("[<color=grey>Xe</color><color=cyan>non</color>]: " + index.toolTip);
												try
												{
													index.disableMethod.Invoke();
												}
												catch
												{
												}
											}
										}
									}
									else
									{
										bool flag11 = index.method != null;
										if (flag11)
										{
											NotifiLib.SendNotification("[<color=grey>Xe</color><color=cyan>non</color>]: " + index.toolTip);
											try
											{
												index.method.Invoke();
											}
											catch
											{
											}
										}
									}
								}
								else
								{
									Debug.LogError(buttonText + " does not exist");
								}
							}
						}
					}
				}
			}
			Main.RecreateMenu();
		}

		// Token: 0x060000B8 RID: 184 RVA: 0x00008650 File Offset: 0x00006850
		public static ButtonInfo GetIndex(string buttonText)
		{
			foreach (ButtonInfo[] array in Buttons.buttons)
			{
				foreach (ButtonInfo buttonInfo in array)
				{
					bool flag = buttonInfo.buttonText == buttonText;
					if (flag)
					{
						return buttonInfo;
					}
				}
			}
			return null;
		}

		// Token: 0x060000B9 RID: 185 RVA: 0x000086B8 File Offset: 0x000068B8
		public static GradientColorKey[] GetSolidGradient(Color color, float v)
		{
			return new GradientColorKey[]
			{
				new GradientColorKey(color, 0f),
				new GradientColorKey(color, 1f)
			};
		}

		// Token: 0x060000BA RID: 186 RVA: 0x000086F4 File Offset: 0x000068F4
		public static void UpdateThemeButtonTexts()
		{
			ButtonInfo[] array = Buttons.buttons[2];
			foreach (ButtonInfo buttonInfo in array)
			{
				bool flag = buttonInfo.buttonText.StartsWith("Background Theme [");
				if (flag)
				{
					buttonInfo.buttonText = "Background Theme [" + Settings.menuBackgroundThemes[Settings.currentBackgroundThemeIndex].Item1 + "]";
				}
				else
				{
					bool flag2 = buttonInfo.buttonText.StartsWith("Button Theme [");
					if (flag2)
					{
						buttonInfo.buttonText = "Button Theme [" + Settings.menuButtonThemes[Settings.currentButtonThemeIndex].Item1 + "]";
					}
				}
			}
		}

		// Token: 0x060000BB RID: 187 RVA: 0x000087A8 File Offset: 0x000069A8
		public static void CycleMenuTheme()
		{
			Settings.currentButtonThemeIndex = (Settings.currentButtonThemeIndex + 1) % Settings.menuButtonThemes.Length;
			ValueTuple<string, Color> valueTuple = Settings.menuButtonThemes[Settings.currentButtonThemeIndex];
			Settings.buttonColors[0].colors = Main.GetSolidGradient(valueTuple.Item2, 1f);
			Main.UpdateThemeButtonTexts();
			Main.RecreateMenu();
		}

		// Token: 0x060000BC RID: 188 RVA: 0x00008804 File Offset: 0x00006A04
		public static void CycleMenuBackgroundTheme()
		{
			Settings.currentBackgroundThemeIndex = (Settings.currentBackgroundThemeIndex + 1) % Settings.menuBackgroundThemes.Length;
			ValueTuple<string, Color> valueTuple = Settings.menuBackgroundThemes[Settings.currentBackgroundThemeIndex];
			Settings.backgroundColor.colors = Main.GetSolidGradient(valueTuple.Item2, 1f);
			Main.UpdateThemeButtonTexts();
			Main.RecreateMenu();
		}

		// Token: 0x060000BD RID: 189 RVA: 0x0000885C File Offset: 0x00006A5C
		public static void RandomizeMenuTheme()
		{
			Settings.currentBackgroundThemeIndex = Random.Range(0, Settings.menuBackgroundThemes.Length);
			ValueTuple<string, Color> valueTuple = Settings.menuBackgroundThemes[Settings.currentBackgroundThemeIndex];
			Settings.backgroundColor.colors = Main.GetSolidGradient(valueTuple.Item2, 1f);
			Settings.currentButtonThemeIndex = Random.Range(0, Settings.menuButtonThemes.Length);
			ValueTuple<string, Color> valueTuple2 = Settings.menuButtonThemes[Settings.currentButtonThemeIndex];
			Settings.buttonColors[0].colors = Main.GetSolidGradient(valueTuple2.Item2, 1f);
			Main.RecreateMenu();
		}

		// Token: 0x060000BE RID: 190 RVA: 0x000088EC File Offset: 0x00006AEC
		public static void ResetMenuThemes()
		{
			Settings.currentBackgroundThemeIndex = 0;
			Settings.currentButtonThemeIndex = 0;
			Settings.currentThemeNameIndex = 0;
			Settings.backgroundColor.colors = Main.GetSolidGradient(Settings.menuBackgroundThemes[0].Item2, 1f);
			Settings.buttonColors[0].colors = Main.GetSolidGradient(Settings.menuButtonThemes[0].Item2, 1f);
			Main.RecreateMenu();
		}

		// Token: 0x060000BF RID: 191 RVA: 0x0000895C File Offset: 0x00006B5C
		public static void ColorLib2(Color color, object target = null)
		{
			PlayerPrefs.SetFloat("redValue", Mathf.Clamp(color.r, 0f, 1f));
			PlayerPrefs.SetFloat("greenValue", Mathf.Clamp(color.g, 0f, 1f));
			PlayerPrefs.SetFloat("blueValue", Mathf.Clamp(color.b, 0f, 1f));
			GorillaTagger.Instance.UpdateColor(color.r, color.g, color.b);
			PlayerPrefs.Save();
			try
			{
				bool flag = target == null;
				if (flag)
				{
					GorillaTagger.Instance.myVRRig.SendRPC("RPC_InitializeNoobMaterial", 0, new object[]
					{
						color.r,
						color.g,
						color.b
					});
				}
				else
				{
					NetPlayer netPlayer = target as NetPlayer;
					bool flag2 = netPlayer != null;
					if (flag2)
					{
						GorillaTagger.Instance.myVRRig.SendRPC("RPC_InitializeNoobMaterial", netPlayer, new object[]
						{
							color.r,
							color.g,
							color.b
						});
					}
					else
					{
						RpcTarget rpcTarget;
						bool flag3;
						if (target is RpcTarget)
						{
							rpcTarget = (RpcTarget)target;
							flag3 = true;
						}
						else
						{
							flag3 = false;
						}
						bool flag4 = flag3;
						if (flag4)
						{
							GorillaTagger.Instance.myVRRig.SendRPC("RPC_InitializeNoobMaterial", rpcTarget, new object[]
							{
								color.r,
								color.g,
								color.b
							});
						}
					}
				}
			}
			catch
			{
			}
		}

		// Token: 0x060000C0 RID: 192 RVA: 0x00008B20 File Offset: 0x00006D20
		public static void Render(Vector3 position, float range, Color color)
		{
			GameObject gameObject = GameObject.CreatePrimitive(0);
			Object.Destroy(gameObject, Time.deltaTime);
			Object.Destroy(gameObject.GetComponent<Collider>());
			Object.Destroy(gameObject.GetComponent<Rigidbody>());
			gameObject.transform.position = position;
			gameObject.transform.localScale = new Vector3(range, range, range);
			Color color2 = color;
			color2.a = 0.25f;
			gameObject.GetComponent<Renderer>().material.shader = Shader.Find("GUI/Text Shader");
			gameObject.GetComponent<Renderer>().material.color = color2;
		}

		// Token: 0x060000C1 RID: 193 RVA: 0x00008BB8 File Offset: 0x00006DB8
		public static Texture2D LoadTextureFromResource(string resourceName)
		{
			Assembly executingAssembly = Assembly.GetExecutingAssembly();
			Texture2D result;
			using (Stream manifestResourceStream = executingAssembly.GetManifestResourceStream("Xenon.Resources." + resourceName))
			{
				bool flag = manifestResourceStream == null;
				if (flag)
				{
					Debug.LogError("Resource not found: " + resourceName);
					result = null;
				}
				else
				{
					byte[] array;
					using (MemoryStream memoryStream = new MemoryStream())
					{
						manifestResourceStream.CopyTo(memoryStream);
						array = memoryStream.ToArray();
					}
					Texture2D texture2D = new Texture2D(2, 2);
					bool flag2 = ImageConversion.LoadImage(texture2D, array);
					if (flag2)
					{
						Debug.Log("Loaded texture: " + resourceName);
						result = texture2D;
					}
					else
					{
						Debug.LogError("Failed to load image from resource stream.");
						result = null;
					}
				}
			}
			return result;
		}

		// Token: 0x040000F1 RID: 241
		public const int buttonsPerPage = 4;

		// Token: 0x040000F2 RID: 242
		private const float BUTTON_SPACING = 0.09f;

		// Token: 0x040000F3 RID: 243
		private const float CORNER_ROUNDNESS = 0.075f;

		// Token: 0x040000F4 RID: 244
		private const float BUTTON_CORNER_ROUNDNESS = 0.03f;

		// Token: 0x040000F5 RID: 245
		private const float OPEN_ANIMATION_SPEED = 0.45f;

		// Token: 0x040000F6 RID: 246
		private const float CLOSE_ANIMATION_SPEED = 0.35f;

		// Token: 0x040000F7 RID: 247
		private const float WOBBLE_OPEN_SPEED = 0.8f;

		// Token: 0x040000F8 RID: 248
		private const float WOBBLE_CLOSE_SPEED = 0.5f;

		// Token: 0x040000F9 RID: 249
		private const float ELASTIC_OPEN_SPEED = 0.6f;

		// Token: 0x040000FA RID: 250
		private const float ELASTIC_CLOSE_SPEED = 0.4f;

		// Token: 0x040000FB RID: 251
		public static string openSfxUrl = "https://github.com/G3IF/Menu-Sounds/raw/refs/heads/main/Open.mp3";

		// Token: 0x040000FC RID: 252
		public static string closeSfxUrl = "https://github.com/G3IF/Menu-Sounds/raw/refs/heads/main/Close.mp3";

		// Token: 0x040000FD RID: 253
		public static string buttonSfxUrl = "https://github.com/G3IF/Menu-Sounds/raw/refs/heads/main/Click.mp3";

		// Token: 0x040000FE RID: 254
		public static string BackGroundMusic = "https://github.com/cheesecomcomyep-jpg/K9-Theme-/blob/main/The%20K9%20Background%20Music.mp3";

		// Token: 0x040000FF RID: 255
		public static GameObject menu;

		// Token: 0x04000100 RID: 256
		public static GameObject menu2;

		// Token: 0x04000101 RID: 257
		public static GameObject menuBackground2;

		// Token: 0x04000102 RID: 258
		public static GameObject menuBackground;

		// Token: 0x04000103 RID: 259
		public static GameObject reference;

		// Token: 0x04000104 RID: 260
		public static GameObject canvasObject;

		// Token: 0x04000105 RID: 261
		public static Camera TPC;

		// Token: 0x04000106 RID: 262
		public static Text fpsObject;

		// Token: 0x04000107 RID: 263
		public static SphereCollider buttonCollider;

		// Token: 0x04000108 RID: 264
		public static int pageNumber = 0;

		// Token: 0x04000109 RID: 265
		public static int buttonsType = 0;

		// Token: 0x0400010A RID: 266
		public static bool Close = false;

		// Token: 0x0400010B RID: 267
		public static bool boardshit = true;

		// Token: 0x0400010C RID: 268
		public static Texture2D homeIcon;

		// Token: 0x0400010D RID: 269
		public static Texture2D settingsIcon;

		// Token: 0x0400010E RID: 270
		public static Texture2D enabledIcon;

		// Token: 0x0400010F RID: 271
		public static Texture2D disconnectIcon;

		// Token: 0x04000110 RID: 272
		public static Material homeMat;

		// Token: 0x04000111 RID: 273
		public static Material settingsMat;

		// Token: 0x04000112 RID: 274
		public static Material enabledMat;

		// Token: 0x04000113 RID: 275
		public static Material disconnectMat;

		// Token: 0x04000114 RID: 276
		public static Material bgMat = new Material(Shader.Find("GorillaTag/UberShader"));

		// Token: 0x04000115 RID: 277
		public static Material ForestMat = null;

		// Token: 0x04000116 RID: 278
		public static Material StumpMat = null;

		// Token: 0x04000117 RID: 279
		public static bool shouldStar = true;

		// Token: 0x04000118 RID: 280
		public static bool shouldHome = false;

		// Token: 0x04000119 RID: 281
		public static bool shouldNext = true;

		// Token: 0x0400011A RID: 282
		public static bool shouldPrev = true;

		// Token: 0x0400011B RID: 283
		public static bool shouldConfig = true;

		// Token: 0x0400011C RID: 284
		public static bool masterNotif = false;

		// Token: 0x0400011D RID: 285
		public static bool shouldPanic = true;

		// Token: 0x0400011E RID: 286
		public static bool lastMasterClient;

		// Token: 0x0400011F RID: 287
		public static bool shouldAnimate = false;

		// Token: 0x04000120 RID: 288
		public static bool noround = false;

		// Token: 0x04000121 RID: 289
		public static bool oulineing = false;

		// Token: 0x04000122 RID: 290
		public static bool Outlineint = true;

		// Token: 0x04000123 RID: 291
		public static bool Ani4;

		// Token: 0x04000124 RID: 292
		public static string StumpLeaderboardID = "UnityTempFile";

		// Token: 0x04000125 RID: 293
		public static string ForestLeaderboardID = "UnityTempFile";

		// Token: 0x04000126 RID: 294
		public static int StumpLeaderboardIndex = 5;

		// Token: 0x04000127 RID: 295
		public static int ForestLeaderboardIndex = 9;

		// Token: 0x04000128 RID: 296
		public static int Theme = 1;

		// Token: 0x04000129 RID: 297
		public static Color32 BgColor1 = new Color32(6, 6, 6, byte.MaxValue);

		// Token: 0x0400012A RID: 298
		public static Color32 BgColor2 = new Color32(14, 14, 14, byte.MaxValue);

		// Token: 0x0400012B RID: 299
		public static List<TextMeshPro> udTMP = new List<TextMeshPro>();
	}
}
