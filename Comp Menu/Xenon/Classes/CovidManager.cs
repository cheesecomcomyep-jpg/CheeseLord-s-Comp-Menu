using System;
using System.Collections;
using UnityEngine;

namespace Xenon.Classes
{
	// Token: 0x02000008 RID: 8
	public class CovidManager : MonoBehaviour
	{
		// Token: 0x06000039 RID: 57 RVA: 0x00003295 File Offset: 0x00001495
		private void Awake()
		{
			CovidManager.instance = this;
		}

		// Token: 0x0600003A RID: 58 RVA: 0x0000329D File Offset: 0x0000149D
		public static Coroutine RunCoroutine(IEnumerator enumerator)
		{
			return CovidManager.instance.StartCoroutine(enumerator);
		}

		// Token: 0x0600003B RID: 59 RVA: 0x000032AA File Offset: 0x000014AA
		public static void EndCoroutine(Coroutine enumerator)
		{
			CovidManager.instance.StopCoroutine(enumerator);
		}

		// Token: 0x04000015 RID: 21
		public static CovidManager instance;
	}
}
