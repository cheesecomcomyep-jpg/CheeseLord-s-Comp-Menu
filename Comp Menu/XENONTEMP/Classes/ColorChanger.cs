using System;
using UnityEngine;

namespace XENONTEMP.Classes
{
	// Token: 0x02000023 RID: 35
	public class ColorChanger : TimedBehaviour
	{
		// Token: 0x060000C7 RID: 199 RVA: 0x00008EB8 File Offset: 0x000070B8
		public override void Start()
		{
			base.Start();
			this.renderer = base.GetComponent<Renderer>();
			this.Update();
		}

		// Token: 0x060000C8 RID: 200 RVA: 0x00008ED8 File Offset: 0x000070D8
		public override void Update()
		{
			base.Update();
			bool flag = this.colorInfo != null;
			if (flag)
			{
				bool flag2 = !this.colorInfo.copyRigColors;
				if (flag2)
				{
					Color color = new Gradient
					{
						colorKeys = this.colorInfo.colors
					}.Evaluate(Time.time / 2f % 1f);
					bool isRainbow = this.colorInfo.isRainbow;
					if (isRainbow)
					{
						float num = (float)Time.frameCount / 180f % 1f;
						color = Color.HSVToRGB(num, 1f, 1f);
					}
					this.renderer.material.color = color;
				}
				else
				{
					this.renderer.material = GorillaTagger.Instance.offlineVRRig.mainSkin.material;
				}
			}
		}

		// Token: 0x04000137 RID: 311
		public Renderer renderer;

		// Token: 0x04000138 RID: 312
		public ExtGradient colorInfo;
	}
}
