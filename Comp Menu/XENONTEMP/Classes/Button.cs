using System;
using UnityEngine;
using XENONTEMP.Menu;

namespace XENONTEMP.Classes
{
	// Token: 0x02000021 RID: 33
	internal class Button : MonoBehaviour
	{
		// Token: 0x060000C4 RID: 196 RVA: 0x00008DB0 File Offset: 0x00006FB0
		public void OnTriggerEnter(Collider collider)
		{
			bool flag = Time.time > Button.buttonCooldown && collider == Main.buttonCollider && Main.menu != null;
			if (flag)
			{
				Button.buttonCooldown = Time.time + 0.2f;
				GorillaTagger.Instance.StartVibration(Settings.rightHanded, GorillaTagger.Instance.tagHapticStrength / 2f, GorillaTagger.Instance.tagHapticDuration / 2f);
				GorillaTagger.Instance.StartCoroutine(Main.PlaySFX(Main.buttonSfxUrl));
				Main.Toggle(this.relatedText);
			}
		}

		// Token: 0x0400012C RID: 300
		public string relatedText;

		// Token: 0x0400012D RID: 301
		public static float buttonCooldown;
	}
}
