using System;
using UnityEngine;

namespace XENONTEMP.Classes
{
	// Token: 0x02000022 RID: 34
	public class ButtonInfo
	{
		// Token: 0x0400012E RID: 302
		public string buttonText = "-";

		// Token: 0x0400012F RID: 303
		public string overlapText = null;

		// Token: 0x04000130 RID: 304
		public Action method = null;

		// Token: 0x04000131 RID: 305
		public Action enableMethod = null;

		// Token: 0x04000132 RID: 306
		public Action disableMethod = null;

		// Token: 0x04000133 RID: 307
		public bool enabled = false;

		// Token: 0x04000134 RID: 308
		public bool isTogglable = true;

		// Token: 0x04000135 RID: 309
		public string toolTip = "This button doesn't have a tooltip/tutorial.";

		// Token: 0x04000136 RID: 310
		public Color? assignedColor = default(Color?);
	}
}
