using System;
using BepInEx;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

namespace XENONTEMP.Classes
{
	// Token: 0x02000025 RID: 37
	internal class RigManager : BaseUnityPlugin
	{
		// Token: 0x060000CB RID: 203 RVA: 0x0000900C File Offset: 0x0000720C
		public static bool RigIsInfected(VRRig vrrig)
		{
			bool flag = vrrig == null || vrrig.mainSkin == null || vrrig.mainSkin.material == null;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				string name = vrrig.mainSkin.material.name;
				result = (name.Contains("fected") || name.Contains("It"));
			}
			return result;
		}

		// Token: 0x060000CC RID: 204 RVA: 0x00009084 File Offset: 0x00007284
		public static bool IsOtherPlayer(VRRig rig)
		{
			return rig != null && rig != GorillaTagger.Instance.offlineVRRig && !rig.isOfflineVRRig && !rig.isMyPlayer;
		}

		// Token: 0x060000CD RID: 205 RVA: 0x000090C5 File Offset: 0x000072C5
		public static PhotonView rig2view(VRRig p)
		{
			return p.GetComponent<NetworkView>().GetView;
		}

		// Token: 0x060000CE RID: 206 RVA: 0x000090D2 File Offset: 0x000072D2
		public static Player NetPlayerToPlayer(NetPlayer np)
		{
			return np.GetPlayerRef();
		}

		// Token: 0x060000CF RID: 207 RVA: 0x000090DC File Offset: 0x000072DC
		public static NetPlayer PlayerToNetPlayer(Player np)
		{
			foreach (NetPlayer netPlayer in NetworkSystem.Instance.AllNetPlayers)
			{
				bool flag = np.UserId == netPlayer.UserId;
				if (flag)
				{
					return netPlayer;
				}
			}
			return null;
		}

		// Token: 0x060000D0 RID: 208 RVA: 0x0000912B File Offset: 0x0000732B
		public static NetworkView GetNetViewFromVRRig(VRRig p)
		{
			return p.GetComponent<NetworkView>();
		}

		// Token: 0x060000D1 RID: 209 RVA: 0x00009133 File Offset: 0x00007333
		public static VRRig GetRigFromPlayer(Player p)
		{
			return GorillaGameManager.instance.FindPlayerVRRig(p);
		}

		// Token: 0x060000D2 RID: 210 RVA: 0x00009145 File Offset: 0x00007345
		public static PhotonView GetViewFromPlayer(Player p)
		{
			return RigManager.rig2view(GorillaGameManager.instance.FindPlayerVRRig(p));
		}

		// Token: 0x060000D3 RID: 211 RVA: 0x0000915C File Offset: 0x0000735C
		public static VRRig GetOwnVRRig()
		{
			return GorillaTagger.Instance.offlineVRRig;
		}

		// Token: 0x060000D4 RID: 212 RVA: 0x00009168 File Offset: 0x00007368
		public static PhotonView GetViewFromRig(VRRig rig)
		{
			return RigManager.rig2view(rig);
		}

		// Token: 0x060000D5 RID: 213 RVA: 0x00009170 File Offset: 0x00007370
		public static NetworkView GetNetViewFromRig(VRRig rig)
		{
			return RigManager.rig2netview(rig);
		}

		// Token: 0x060000D6 RID: 214 RVA: 0x00009178 File Offset: 0x00007378
		public static NetPlayer GetPlayerFromID(string id)
		{
			NetPlayer result = null;
			foreach (Player player in PhotonNetwork.PlayerList)
			{
				bool flag = player.UserId == id;
				if (flag)
				{
					result = player;
					break;
				}
			}
			return result;
		}

		// Token: 0x060000D7 RID: 215 RVA: 0x000091C8 File Offset: 0x000073C8
		public static NetworkView rig2netview(VRRig p)
		{
			return p.GetComponent<NetworkView>();
		}

		// Token: 0x060000D8 RID: 216 RVA: 0x000091E0 File Offset: 0x000073E0
		public static Player GetPlayerFromRig(VRRig rig)
		{
			return rig.OwningNetPlayer.GetPlayerRef();
		}

		// Token: 0x060000D9 RID: 217 RVA: 0x00009200 File Offset: 0x00007400
		public static NetPlayer GetNetPlayerFromRig(VRRig rig)
		{
			return rig.OwningNetPlayer;
		}

		// Token: 0x060000DA RID: 218 RVA: 0x00009218 File Offset: 0x00007418
		private float Distance2D(Vector3 a, Vector3 b)
		{
			Vector2 vector;
			vector..ctor(a.x, a.z);
			Vector2 vector2;
			vector2..ctor(b.x, b.z);
			return Vector2.Distance(vector, vector2);
		}

		// Token: 0x060000DB RID: 219 RVA: 0x00009258 File Offset: 0x00007458
		private bool PlayerNear(VRRig rig, float dist, out float playerDist)
		{
			bool flag = rig == null;
			bool result;
			if (flag)
			{
				playerDist = float.PositiveInfinity;
				result = false;
			}
			else
			{
				playerDist = this.Distance2D(rig.transform.position, base.transform.position);
				result = (playerDist < dist && Physics.RaycastNonAlloc(new Ray(base.transform.position, rig.transform.position - base.transform.position), this.rayResults, playerDist, UnityLayerExtensions.ToLayerMask(0) | UnityLayerExtensions.ToLayerMask(9)) <= 0);
			}
			return result;
		}

		// Token: 0x060000DC RID: 220 RVA: 0x000092F4 File Offset: 0x000074F4
		private bool ClosestPlayer(in Vector3 myPos, out VRRig outRig)
		{
			float num = float.MaxValue;
			outRig = null;
			foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
			{
				float num2 = 0f;
				bool flag = this.PlayerNear(vrrig, GorillaGameManager.instance.tagDistanceThreshold, out num2) && num2 < num;
				if (flag)
				{
					num = num2;
					outRig = vrrig;
				}
			}
			return num != float.MaxValue;
		}

		// Token: 0x060000DD RID: 221 RVA: 0x00009394 File Offset: 0x00007594
		public static bool battleIsOnCooldown(VRRig rig)
		{
			return rig.mainSkin.material.name.Contains("hit");
		}

		// Token: 0x060000DE RID: 222 RVA: 0x000093B0 File Offset: 0x000075B0
		public static Player GetRandomPlayer(bool includeSelf)
		{
			return includeSelf ? PhotonNetwork.PlayerList[Random.Range(0, PhotonNetwork.PlayerList.Length)] : PhotonNetwork.PlayerListOthers[Random.Range(0, PhotonNetwork.PlayerListOthers.Length)];
		}

		// Token: 0x060000DF RID: 223 RVA: 0x000093E0 File Offset: 0x000075E0
		public static NetPlayer GetRandomNetPlayer(bool includeSelf)
		{
			return includeSelf ? NetworkSystem.Instance.AllNetPlayers[Random.Range(0, NetworkSystem.Instance.AllNetPlayers.Length)] : NetworkSystem.Instance.PlayerListOthers[Random.Range(0, NetworkSystem.Instance.PlayerListOthers.Length)];
		}

		// Token: 0x060000E0 RID: 224 RVA: 0x0000942C File Offset: 0x0000762C
		public static VRRig GetRandomVRRig(bool includeSelf)
		{
			return RigManager.GetRigFromPlayer(RigManager.GetRandomPlayer(includeSelf));
		}

		// Token: 0x0400013C RID: 316
		private RaycastHit[] rayResults = new RaycastHit[1];
	}
}
