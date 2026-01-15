using System;
using UnityEngine;

namespace XENONTEMP.Classes
{
	// Token: 0x02000024 RID: 36
	public class ExtGradient
	{
		// Token: 0x04000139 RID: 313
		public GradientColorKey[] colors = new GradientColorKey[]
		{
			new GradientColorKey(new Color32(25, 25, 25, byte.MaxValue), 0f)
		};

		// Token: 0x0400013A RID: 314
		public bool isRainbow = false;

		// Token: 0x0400013B RID: 315
		public bool copyRigColors = false;
	}
}
