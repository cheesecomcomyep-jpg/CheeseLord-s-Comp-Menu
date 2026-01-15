using System;
using UnityEngine;

namespace Xenon.Mods
{
	// Token: 0x02000007 RID: 7
	internal class Visual
	{
		// Token: 0x06000033 RID: 51 RVA: 0x00002EDC File Offset: 0x000010DC
		public static void CubeESP()
		{
			foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
			{
				GameObject gameObject = GameObject.CreatePrimitive(3);
				gameObject.transform.position = vrrig.transform.position;
				gameObject.transform.localScale = new Vector3(0.75f, 0.75f, 0.75f);
				gameObject.transform.rotation = vrrig.transform.rotation;
				Object.Destroy(gameObject.GetComponent<Collider>());
				Object.Destroy(gameObject, Time.deltaTime);
			}
		}

		// Token: 0x06000034 RID: 52 RVA: 0x00002FA0 File Offset: 0x000011A0
		public static void Tracers1()
		{
			foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
			{
				GameObject gameObject = new GameObject("Line");
				LineRenderer lineRenderer = gameObject.AddComponent<LineRenderer>();
				lineRenderer.startColor = Color.purple;
				lineRenderer.startWidth = 0.035f;
				lineRenderer.endWidth = 0.055f;
				lineRenderer.useWorldSpace = true;
				lineRenderer.material = new Material(Shader.Find("GUI/Text Shader"));
				lineRenderer.endColor = Color.black;
			}
		}

		// Token: 0x06000035 RID: 53 RVA: 0x00003058 File Offset: 0x00001258
		public static void Tracers2()
		{
			foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
			{
				GameObject gameObject = new GameObject("Line");
				LineRenderer lineRenderer = gameObject.AddComponent<LineRenderer>();
				lineRenderer.startColor = Color.cyan;
				lineRenderer.startWidth = 0.035f;
				lineRenderer.endWidth = 0.055f;
				lineRenderer.useWorldSpace = true;
				lineRenderer.material = new Material(Shader.Find("GUI/Text Shader"));
				lineRenderer.endColor = Color.black;
			}
		}

		// Token: 0x06000036 RID: 54 RVA: 0x00003110 File Offset: 0x00001310
		public static void Tracers3()
		{
			foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
			{
				GameObject gameObject = new GameObject("Line");
				LineRenderer lineRenderer = gameObject.AddComponent<LineRenderer>();
				lineRenderer.startColor = Color.gold;
				lineRenderer.startWidth = 0.035f;
				lineRenderer.endWidth = 0.055f;
				lineRenderer.useWorldSpace = true;
				lineRenderer.material = new Material(Shader.Find("GUI/Text Shader"));
				lineRenderer.endColor = Color.black;
			}
		}

		// Token: 0x06000037 RID: 55 RVA: 0x000031C8 File Offset: 0x000013C8
		public static void SphereESP()
		{
			foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
			{
				GameObject gameObject = GameObject.CreatePrimitive(0);
				gameObject.transform.position = vrrig.transform.position;
				gameObject.transform.localScale = new Vector3(0.75f, 0.75f, 0.75f);
				gameObject.transform.rotation = vrrig.transform.rotation;
				Object.Destroy(gameObject.GetComponent<Collider>());
				Object.Destroy(gameObject, Time.deltaTime);
			}
		}
	}
}
