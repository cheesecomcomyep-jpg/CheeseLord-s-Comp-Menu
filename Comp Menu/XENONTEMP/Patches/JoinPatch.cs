using System;
using HarmonyLib;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using XENONTEMP.Notifications;

namespace XENONTEMP.Patches
{
	// Token: 0x0200000C RID: 12
	[HarmonyPatch(typeof(MonoBehaviourPunCallbacks), "OnPlayerEnteredRoom")]
	internal class JoinPatch : MonoBehaviour
	{
		// Token: 0x06000043 RID: 67 RVA: 0x00004E50 File Offset: 0x00003050
		private static void Prefix(Player newPlayer)
		{
			bool flag = newPlayer != JoinPatch.oldnewplayer;
			if (flag)
			{
				NotifiLib.SendNotification("[<color=grey>Co</color><color=cyan>mp</color>]: " + newPlayer.NickName + " joined!");
				JoinPatch.oldnewplayer = newPlayer;
			}
		}

		// Token: 0x040000DE RID: 222
		private static Player oldnewplayer;
	}
}
