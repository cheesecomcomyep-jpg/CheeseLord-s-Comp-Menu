using System;
using GorillaNetworking;

namespace XENONTEMP.Classes
{
	// Token: 0x02000026 RID: 38
	internal class RoomManager
	{
		// Token: 0x060000E2 RID: 226 RVA: 0x0000944E File Offset: 0x0000764E
		public static void Join(string roomToJoin)
		{
			PhotonNetworkController.Instance.AttemptToJoinSpecificRoom(roomToJoin, 0);
		}
	}
}
