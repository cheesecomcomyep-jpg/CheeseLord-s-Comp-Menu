using System;
using GorillaLocomotion;
using Gunlib;
using UnityEngine;

namespace Xenon.Mods
{
	// Token: 0x02000005 RID: 5
	internal class Movement
	{
		// Token: 0x0600001D RID: 29 RVA: 0x00002A09 File Offset: 0x00000C09
		public static void FasterSpeedBoost()
		{
			GTPlayer.Instance.maxJumpSpeed = 5f;
			GTPlayer.Instance.jumpMultiplier = 5f;
		}

		// Token: 0x0600001E RID: 30 RVA: 0x00002A2B File Offset: 0x00000C2B
		public static void FastererSpeedBoost()
		{
			GTPlayer.Instance.maxJumpSpeed = 7f;
			GTPlayer.Instance.jumpMultiplier = 7f;
		}

		// Token: 0x0600001F RID: 31 RVA: 0x00002A4D File Offset: 0x00000C4D
		public static void FasterererSpeedBoost()
		{
			GTPlayer.Instance.maxJumpSpeed = 9f;
			GTPlayer.Instance.jumpMultiplier = 9f;
		}

		// Token: 0x06000020 RID: 32 RVA: 0x00002A6F File Offset: 0x00000C6F
		public static void SlowSpeed()
		{
			GTPlayer.Instance.maxJumpSpeed = 2f;
			GTPlayer.Instance.jumpMultiplier = 2f;
		}

		// Token: 0x06000021 RID: 33 RVA: 0x00002A91 File Offset: 0x00000C91
		public static void EvenSlowerSpeed()
		{
			GTPlayer.Instance.maxJumpSpeed = 0.5f;
			GTPlayer.Instance.jumpMultiplier = 0.5f;
		}

		// Token: 0x06000022 RID: 34 RVA: 0x00002AB3 File Offset: 0x00000CB3
		public static void ChangeSpeedBoostPlus()
		{
			Movement.CustomBoostIndex += 1f;
		}

		// Token: 0x06000023 RID: 35 RVA: 0x00002AC6 File Offset: 0x00000CC6
		public static void ChangeSpeedBoostNegitve()
		{
			Movement.CustomBoostIndex -= 1f;
		}

		// Token: 0x06000024 RID: 36 RVA: 0x00002AD9 File Offset: 0x00000CD9
		public static void CustomSpeedBoost()
		{
			GTPlayer.Instance.maxJumpSpeed = Movement.CustomBoostIndex;
			GTPlayer.Instance.jumpMultiplier = Movement.CustomBoostIndex;
		}

		// Token: 0x06000025 RID: 37 RVA: 0x00002AFB File Offset: 0x00000CFB
		public static void MosaSpeed()
		{
			GTPlayer.Instance.maxJumpSpeed = 1.25f;
			GTPlayer.Instance.jumpMultiplier = 3f;
		}

		// Token: 0x06000026 RID: 38 RVA: 0x00002B1D File Offset: 0x00000D1D
		public static void TTTSpeed()
		{
			GTPlayer.Instance.maxJumpSpeed = 1.4f;
			GTPlayer.Instance.jumpMultiplier = 3.25f;
		}

		// Token: 0x06000027 RID: 39 RVA: 0x00002B40 File Offset: 0x00000D40
		public static void PullMod()
		{
			bool leftGrab = ControllerInputPoller.instance.leftGrab;
			if (leftGrab)
			{
				GorillaTagger.Instance.transform.forward = GorillaTagger.Instance.transform.forward * 100f;
			}
		}

		// Token: 0x06000028 RID: 40 RVA: 0x00002B8C File Offset: 0x00000D8C
		public static void Platform()
		{
			bool leftGrab = ControllerInputPoller.instance.leftGrab;
			if (leftGrab)
			{
				bool flag = Movement.Pl == null;
				if (flag)
				{
					Movement.Pl = GameObject.CreatePrimitive(3);
					Movement.Pl.transform.position = GorillaTagger.Instance.leftHandTransform.position;
					Movement.Pl.transform.localScale = new Vector3(0.5f, 0.2f, 0.5f);
					Movement.Pl.transform.rotation = GorillaTagger.Instance.leftHandTransform.rotation;
				}
				else
				{
					bool flag2 = Movement.Pl != null;
					if (flag2)
					{
						Object.Destroy(Movement.Pl);
						Movement.Pl = null;
					}
				}
			}
			bool rightGrab = ControllerInputPoller.instance.rightGrab;
			if (rightGrab)
			{
				bool flag3 = Movement.Pr == null;
				if (flag3)
				{
					Movement.Pr = GameObject.CreatePrimitive(3);
					Movement.Pr.transform.position = GorillaTagger.Instance.leftHandTransform.position;
					Movement.Pr.transform.localScale = new Vector3(0.5f, 0.2f, 0.5f);
					Movement.Pr.transform.rotation = GorillaTagger.Instance.leftHandTransform.rotation;
				}
				else
				{
					bool flag4 = Movement.Pr != null;
					if (flag4)
					{
						Object.Destroy(Movement.Pr);
						Movement.Pr = null;
					}
				}
			}
		}

		// Token: 0x06000029 RID: 41 RVA: 0x00002D10 File Offset: 0x00000F10
		public static void WallWalk()
		{
			bool rightGrab = ControllerInputPoller.instance.rightGrab;
			if (rightGrab)
			{
				GTPlayer.Instance.bodyCollider.attachedRigidbody.AddForce(GTPlayer.Instance.bodyCollider.transform.right * (Time.deltaTime * (3f / Time.deltaTime)), 5);
			}
			bool leftGrab = ControllerInputPoller.instance.leftGrab;
			if (leftGrab)
			{
				GTPlayer.Instance.bodyCollider.attachedRigidbody.AddForce(GTPlayer.Instance.bodyCollider.transform.right * (Time.deltaTime * (-3f / Time.deltaTime)), 5);
			}
		}

		// Token: 0x0600002A RID: 42 RVA: 0x00002DC2 File Offset: 0x00000FC2
		public static void NoGravity()
		{
			Physics.gravity = new Vector3(0f, 0f, 0f);
		}

		// Token: 0x0600002B RID: 43 RVA: 0x00002DDF File Offset: 0x00000FDF
		public static void HighGravity()
		{
			Physics.gravity = new Vector3(0f, -10f, 0f);
		}

		// Token: 0x0600002C RID: 44 RVA: 0x00002DFC File Offset: 0x00000FFC
		public static void FixGrav()
		{
			Physics.gravity = new Vector3(0f, -9.81f, 0f);
		}

		// Token: 0x0600002D RID: 45 RVA: 0x00002E1C File Offset: 0x0000101C
		public static void Noclip()
		{
			foreach (MeshCollider meshCollider in Resources.FindObjectsOfTypeAll<MeshCollider>())
			{
				meshCollider.enabled = false;
			}
		}

		// Token: 0x0600002E RID: 46 RVA: 0x00002E4D File Offset: 0x0000104D
		public static void AirStrikeGun()
		{
			GunTemplate.StartBothGuns(delegate
			{
				GTPlayer.Instance.transform.position = GunTemplate.spherepointer.transform.position;
				GTPlayer.Instance.GetComponent<Rigidbody>().linearVelocity = new Vector3(0f, 100f, 0f);
			}, true);
		}

		// Token: 0x0600002F RID: 47 RVA: 0x00002E78 File Offset: 0x00001078
		public static void FastSwim()
		{
			bool inWater = GTPlayer.Instance.InWater;
			if (inWater)
			{
				GTPlayer.Instance.gameObject.GetComponent<Rigidbody>().linearVelocity *= 1.04f;
			}
		}

		// Token: 0x04000012 RID: 18
		public static float CustomBoostIndex = 2f;

		// Token: 0x04000013 RID: 19
		public static GameObject Pl;

		// Token: 0x04000014 RID: 20
		public static GameObject Pr;
	}
}
