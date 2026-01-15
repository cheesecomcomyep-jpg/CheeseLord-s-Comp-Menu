using System;
using System.Linq;
using BepInEx;
using UnityEngine;
using UnityEngine.UI;

namespace XENONTEMP.Notifications
{
	// Token: 0x0200001C RID: 28
	[BepInPlugin("org.gorillatag.lars.notifications2", "NotificationLibrary", "1.0.5")]
	public class NotifiLib : BaseUnityPlugin
	{
		// Token: 0x06000066 RID: 102 RVA: 0x00005151 File Offset: 0x00003351
		private void Awake()
		{
			base.Logger.LogInfo("Plugin NotificationLibrary is loaded!");
		}

		// Token: 0x06000067 RID: 103 RVA: 0x00005168 File Offset: 0x00003368
		private void Init()
		{
			this.MainCamera = GameObject.Find("Main Camera");
			this.HUDObj = new GameObject();
			this.HUDObj2 = new GameObject();
			this.HUDObj2.name = "NOTIFICATIONLIB_HUD_OBJ";
			this.HUDObj.name = "NOTIFICATIONLIB_HUD_OBJ";
			this.HUDObj.AddComponent<Canvas>();
			this.HUDObj.AddComponent<CanvasScaler>();
			this.HUDObj.AddComponent<GraphicRaycaster>();
			this.HUDObj.GetComponent<Canvas>().enabled = true;
			this.HUDObj.GetComponent<Canvas>().renderMode = 2;
			this.HUDObj.GetComponent<Canvas>().worldCamera = this.MainCamera.GetComponent<Camera>();
			this.HUDObj.GetComponent<RectTransform>().sizeDelta = new Vector2(5f, 5f);
			this.HUDObj.GetComponent<RectTransform>().position = new Vector3(this.MainCamera.transform.position.x, this.MainCamera.transform.position.y, this.MainCamera.transform.position.z);
			this.HUDObj2.transform.position = new Vector3(this.MainCamera.transform.position.x, this.MainCamera.transform.position.y, this.MainCamera.transform.position.z - 4.6f);
			this.HUDObj.transform.parent = this.HUDObj2.transform;
			this.HUDObj.GetComponent<RectTransform>().localPosition = new Vector3(0f, 0f, 1.6f);
			Vector3 eulerAngles = this.HUDObj.GetComponent<RectTransform>().rotation.eulerAngles;
			eulerAngles.y = -270f;
			this.HUDObj.transform.localScale = new Vector3(1f, 1f, 1f);
			this.HUDObj.GetComponent<RectTransform>().rotation = Quaternion.Euler(eulerAngles);
			this.Testtext = new GameObject
			{
				transform = 
				{
					parent = this.HUDObj.transform
				}
			}.AddComponent<Text>();
			this.Testtext.text = "";
			this.Testtext.fontSize = 30;
			this.Testtext.font = Settings.currentFont;
			this.Testtext.rectTransform.sizeDelta = new Vector2(450f, 210f);
			this.Testtext.alignment = 6;
			this.Testtext.rectTransform.localScale = new Vector3(0.0033333334f, 0.0033333334f, 0.33333334f);
			this.Testtext.rectTransform.localPosition = new Vector3(-1f, -1f, -0.5f);
			this.Testtext.material = this.AlertText;
			NotifiLib.NotifiText = this.Testtext;
		}

		// Token: 0x06000068 RID: 104 RVA: 0x00005480 File Offset: 0x00003680
		private void FixedUpdate()
		{
			bool flag = !this.HasInit && GameObject.Find("Main Camera") != null;
			bool flag2 = flag;
			if (flag2)
			{
				this.Init();
				this.HasInit = true;
			}
			this.HUDObj2.transform.position = new Vector3(this.MainCamera.transform.position.x, this.MainCamera.transform.position.y, this.MainCamera.transform.position.z);
			this.HUDObj2.transform.rotation = this.MainCamera.transform.rotation;
			bool flag3 = this.Testtext.text != "";
			if (flag3)
			{
				this.NotificationDecayTimeCounter++;
				bool flag4 = this.NotificationDecayTimeCounter > this.NotificationDecayTime;
				if (flag4)
				{
					this.Notifilines = null;
					this.newtext = "";
					this.NotificationDecayTimeCounter = 0;
					this.Notifilines = Enumerable.ToArray<string>(Enumerable.Skip<string>(this.Testtext.text.Split(Environment.NewLine.ToCharArray()), 1));
					foreach (string text in this.Notifilines)
					{
						bool flag5 = text != "";
						if (flag5)
						{
							this.newtext = this.newtext + text + "\n";
						}
					}
					this.Testtext.text = this.newtext;
				}
			}
			else
			{
				this.NotificationDecayTimeCounter = 0;
			}
		}

		// Token: 0x06000069 RID: 105 RVA: 0x0000562C File Offset: 0x0000382C
		public static void SendNotification(string NotificationText)
		{
			bool flag = !Settings.disableNotifications;
			if (flag)
			{
				try
				{
					bool flag2 = NotifiLib.IsEnabled && NotifiLib.PreviousNotifi != NotificationText;
					if (flag2)
					{
						bool flag3 = !NotificationText.Contains(Environment.NewLine);
						if (flag3)
						{
							NotificationText += Environment.NewLine;
						}
						NotifiLib.NotifiText.text = NotifiLib.NotifiText.text + NotificationText;
						NotifiLib.NotifiText.supportRichText = true;
						NotifiLib.PreviousNotifi = NotificationText;
					}
				}
				catch
				{
					Debug.LogError("Notification failed, object probably nil due to third person ; " + NotificationText);
				}
			}
		}

		// Token: 0x0600006A RID: 106 RVA: 0x000056E0 File Offset: 0x000038E0
		public static void ClearAllNotifications()
		{
			NotifiLib.NotifiText.text = "";
		}

		// Token: 0x0600006B RID: 107 RVA: 0x000056F4 File Offset: 0x000038F4
		public static void ClearPastNotifications(int amount)
		{
			string text = "";
			foreach (string text2 in Enumerable.ToArray<string>(Enumerable.Skip<string>(NotifiLib.NotifiText.text.Split(Environment.NewLine.ToCharArray()), amount)))
			{
				bool flag = text2 != "";
				if (flag)
				{
					text = text + text2 + "\n";
				}
			}
			NotifiLib.NotifiText.text = text;
		}

		// Token: 0x040000E2 RID: 226
		private GameObject HUDObj;

		// Token: 0x040000E3 RID: 227
		private GameObject HUDObj2;

		// Token: 0x040000E4 RID: 228
		private GameObject MainCamera;

		// Token: 0x040000E5 RID: 229
		private Text Testtext;

		// Token: 0x040000E6 RID: 230
		private Material AlertText = new Material(Shader.Find("GUI/Text Shader"));

		// Token: 0x040000E7 RID: 231
		private int NotificationDecayTime = 144;

		// Token: 0x040000E8 RID: 232
		private int NotificationDecayTimeCounter;

		// Token: 0x040000E9 RID: 233
		public static int NoticationThreshold = 30;

		// Token: 0x040000EA RID: 234
		private string[] Notifilines;

		// Token: 0x040000EB RID: 235
		private string newtext;

		// Token: 0x040000EC RID: 236
		public static string PreviousNotifi;

		// Token: 0x040000ED RID: 237
		private bool HasInit;

		// Token: 0x040000EE RID: 238
		private static Text NotifiText;

		// Token: 0x040000EF RID: 239
		public static bool IsEnabled = true;
	}
}
