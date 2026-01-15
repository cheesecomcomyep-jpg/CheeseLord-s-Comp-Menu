using System;
using UnityEngine;

namespace XENONTEMP.Classes
{
	// Token: 0x02000027 RID: 39
	public class TimedBehaviour : MonoBehaviour
	{
		// Token: 0x060000E4 RID: 228 RVA: 0x00009469 File Offset: 0x00007669
		public virtual void Start()
		{
			this.startTime = Time.time;
		}

		// Token: 0x060000E5 RID: 229 RVA: 0x00009478 File Offset: 0x00007678
		public virtual void Update()
		{
			bool flag = !this.complete;
			if (flag)
			{
				this.progress = Mathf.Clamp((Time.time - this.startTime) / this.duration, 0f, 1f);
				bool flag2 = Time.time - this.startTime > this.duration;
				if (flag2)
				{
					bool flag3 = this.loop;
					if (flag3)
					{
						this.OnLoop();
					}
					else
					{
						this.complete = true;
					}
				}
			}
		}

		// Token: 0x060000E6 RID: 230 RVA: 0x000094F5 File Offset: 0x000076F5
		public virtual void OnLoop()
		{
			this.startTime = Time.time;
		}

		// Token: 0x0400013D RID: 317
		public bool complete = false;

		// Token: 0x0400013E RID: 318
		public bool loop = true;

		// Token: 0x0400013F RID: 319
		public float progress = 0f;

		// Token: 0x04000140 RID: 320
		protected bool paused = false;

		// Token: 0x04000141 RID: 321
		protected float startTime;

		// Token: 0x04000142 RID: 322
		protected float duration = 2f;
	}
}
