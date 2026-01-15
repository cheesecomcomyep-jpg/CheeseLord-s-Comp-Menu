using System;
using HarmonyLib;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using XENONTEMP.Notifications;

namespace XENONTEMP.Patches
{
	// Token: 0x0200000D RID: 13
	[HarmonyPatch(typeof(MonoBehaviourPunCallbacks), "OnPlayerLeftRoom")]
	internal class LeavePatch : MonoBehaviour
	{
		// Token: 0x06000045 RID: 69 RVA: 0x00004E9C File Offset: 0x0000309C
		private static void Prefix(Player otherPlayer)
		{
			bool flag = otherPlayer != PhotonNetwork.LocalPlayer && otherPlayer != LeavePatch.a;
			if (flag)
			{
				NotifiLib.SendNotification("[<color=grey>Me</color><color=cyan>nu</color>]: " + otherPlayer.NickName + " left!");
				LeavePatch.a = otherPlayer;
			}
		}

		// Token: 0x040000DF RID: 223
		private static Player a;
	}
}
