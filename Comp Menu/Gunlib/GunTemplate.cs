using System;
using System.Collections;
using BepInEx;
using Colorlib;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;

namespace Gunlib
{
	// Token: 0x02000003 RID: 3
	public class GunTemplate : MonoBehaviour
	{
		// Token: 0x06000003 RID: 3 RVA: 0x00002078 File Offset: 0x00000278
		private static Vector3 CalculateBezierPoint(Vector3 start, Vector3 mid, Vector3 end, float t)
		{
			return Mathf.Pow(1f - t * 1.25f, 2f) * start + 2f * (1f - t * 1.25f) * (t * 1.25f) * mid + Mathf.Pow(t, 2f) * end;
		}

		// Token: 0x06000004 RID: 4 RVA: 0x000020E4 File Offset: 0x000002E4
		private static void CurveLineRenderer(LineRenderer lineRenderer, Vector3 start, Vector3 mid, Vector3 end)
		{
			lineRenderer.positionCount = GunTemplate.LineCurve;
			for (int i = 0; i < GunTemplate.LineCurve; i++)
			{
				float t = (float)i / (float)(GunTemplate.LineCurve - 1);
				lineRenderer.SetPosition(i, GunTemplate.CalculateBezierPoint(start, mid, end, t));
			}
		}

		// Token: 0x06000005 RID: 5 RVA: 0x00002131 File Offset: 0x00000331
		private static IEnumerator StartCurvyLineRenderer(LineRenderer lineRenderer, Vector3 start, Vector3 mid, Vector3 end)
		{
			GunTemplate.<StartCurvyLineRenderer>d__18 <StartCurvyLineRenderer>d__ = new GunTemplate.<StartCurvyLineRenderer>d__18(0);
			<StartCurvyLineRenderer>d__.lineRenderer = lineRenderer;
			<StartCurvyLineRenderer>d__.start = start;
			<StartCurvyLineRenderer>d__.mid = mid;
			<StartCurvyLineRenderer>d__.end = end;
			return <StartCurvyLineRenderer>d__;
		}

		// Token: 0x06000006 RID: 6 RVA: 0x00002155 File Offset: 0x00000355
		private static IEnumerator PulsePointer(GameObject pointer)
		{
			GunTemplate.<PulsePointer>d__19 <PulsePointer>d__ = new GunTemplate.<PulsePointer>d__19(0);
			<PulsePointer>d__.pointer = pointer;
			return <PulsePointer>d__;
		}

		// Token: 0x06000007 RID: 7 RVA: 0x00002164 File Offset: 0x00000364
		public static void StartVrGun(Action action, bool LockOn)
		{
			bool rightGrab = ControllerInputPoller.instance.rightGrab;
			if (rightGrab)
			{
				Physics.Raycast(GorillaTagger.Instance.rightHandTransform.position, -GorillaTagger.Instance.rightHandTransform.up, ref GunTemplate.raycastHit, float.MaxValue);
				bool flag = GunTemplate.spherepointer == null;
				if (flag)
				{
					GunTemplate.CreatePointerSphere();
				}
				GunTemplate.UpdatePointerPosition();
				GunTemplate.lr = Vector3.Lerp(GunTemplate.lr, (GorillaTagger.Instance.rightHandTransform.position + GunTemplate.spherepointer.transform.position) / 2f, Time.deltaTime * 0.5f);
				GunTemplate.CreateGunLine();
				bool flag2 = ControllerInputPoller.instance.rightControllerIndexFloat > 0.5f;
				if (flag2)
				{
					GunTemplate.HandleTriggerPress(action, LockOn);
				}
				else
				{
					bool flag3 = GunTemplate.LockedPlayer != null;
					if (flag3)
					{
						GunTemplate.LockedPlayer = null;
					}
				}
			}
			else
			{
				bool flag4 = GunTemplate.spherepointer != null;
				if (flag4)
				{
					GunTemplate.DestroyGunObjects();
				}
			}
		}

		// Token: 0x06000008 RID: 8 RVA: 0x0000227C File Offset: 0x0000047C
		public static void StartPcGun(Action action, bool LockOn)
		{
			Ray ray = GameObject.Find("Shoulder Camera").activeSelf ? GameObject.Find("Shoulder Camera").GetComponent<Camera>().ScreenPointToRay(UnityInput.Current.mousePosition) : GorillaTagger.Instance.mainCamera.GetComponent<Camera>().ScreenPointToRay(UnityInput.Current.mousePosition);
			bool isPressed = Mouse.current.rightButton.isPressed;
			if (isPressed)
			{
				RaycastHit hit;
				bool flag = Physics.Raycast(ray.origin, ray.direction, ref hit, float.PositiveInfinity, -32777) && GunTemplate.spherepointer == null;
				if (flag)
				{
					bool flag2 = GunTemplate.spherepointer == null;
					if (flag2)
					{
						GunTemplate.CreatePointerSphere();
					}
				}
				bool flag3 = GunTemplate.LockedPlayer == null;
				if (flag3)
				{
					GunTemplate.spherepointer.transform.position = hit.point;
					GunTemplate.spherepointer.GetComponent<Renderer>().material.color = GunTemplate.PointerColor;
				}
				else
				{
					GunTemplate.spherepointer.transform.position = GunTemplate.LockedPlayer.transform.position;
				}
				GunTemplate.lr = Vector3.Lerp(GunTemplate.lr, (GorillaTagger.Instance.rightHandTransform.position + GunTemplate.spherepointer.transform.position) / 2f, Time.deltaTime * 0.5f);
				GunTemplate.CreateGunLine();
				bool isPressed2 = Mouse.current.leftButton.isPressed;
				if (isPressed2)
				{
					GunTemplate.HandlePcTriggerPress(action, LockOn, hit);
				}
				else
				{
					bool flag4 = GunTemplate.LockedPlayer != null;
					if (flag4)
					{
						GunTemplate.LockedPlayer = null;
					}
				}
			}
			else
			{
				bool flag5 = GunTemplate.spherepointer != null;
				if (flag5)
				{
					GunTemplate.DestroyGunObjects();
				}
			}
		}

		// Token: 0x06000009 RID: 9 RVA: 0x00002450 File Offset: 0x00000650
		public static void StartBothGuns(Action action, bool locko)
		{
			bool isDeviceActive = XRSettings.isDeviceActive;
			if (isDeviceActive)
			{
				GunTemplate.StartVrGun(action, locko);
			}
			else
			{
				GunTemplate.StartPcGun(action, locko);
			}
		}

		// Token: 0x0600000A RID: 10 RVA: 0x00002480 File Offset: 0x00000680
		private static void CreatePointerSphere()
		{
			GunTemplate.spherepointer = GameObject.CreatePrimitive(0);
			GunTemplate.spherepointer.AddComponent<Renderer>();
			GunTemplate.spherepointer.transform.localScale = new Vector3(0.04f, 0.04f, 0.04f);
			GunTemplate.spherepointer.GetComponent<Renderer>().material.shader = Shader.Find("GUI/Text Shader");
			Object.Destroy(GunTemplate.spherepointer.GetComponent<BoxCollider>());
			Object.Destroy(GunTemplate.spherepointer.GetComponent<Rigidbody>());
			Object.Destroy(GunTemplate.spherepointer.GetComponent<Collider>());
			GunTemplate.lr = GorillaTagger.Instance.offlineVRRig.rightHandTransform.position;
			GunTemplate.spherepointer.AddComponent<GunTemplate>().StartCoroutine(GunTemplate.PulsePointer(GunTemplate.spherepointer));
		}

		// Token: 0x0600000B RID: 11 RVA: 0x0000254C File Offset: 0x0000074C
		private static void UpdatePointerPosition()
		{
			bool flag = GunTemplate.LockedPlayer == null;
			if (flag)
			{
				GunTemplate.spherepointer.transform.position = GunTemplate.raycastHit.point;
				GunTemplate.spherepointer.GetComponent<Renderer>().material.color = GunTemplate.PointerColor;
			}
			else
			{
				GunTemplate.spherepointer.transform.position = GunTemplate.LockedPlayer.transform.position;
			}
		}

		// Token: 0x0600000C RID: 12 RVA: 0x000025C8 File Offset: 0x000007C8
		private static void CreateGunLine()
		{
			GameObject gameObject = new GameObject("Line");
			LineRenderer lineRenderer = gameObject.AddComponent<LineRenderer>();
			lineRenderer.startColor = Color.purple;
			lineRenderer.startWidth = 0.035f;
			lineRenderer.endWidth = 0.035f;
			lineRenderer.useWorldSpace = true;
			lineRenderer.material = new Material(Shader.Find("GUI/Text Shader"));
			gameObject.AddComponent<GunTemplate>().StartCoroutine(GunTemplate.StartCurvyLineRenderer(lineRenderer, GorillaTagger.Instance.rightHandTransform.position, GunTemplate.lr, GunTemplate.spherepointer.transform.position));
			Object.Destroy(lineRenderer, Time.deltaTime);
			lineRenderer.endColor = Color.black;
		}

		// Token: 0x0600000D RID: 13 RVA: 0x00002678 File Offset: 0x00000878
		private static void HandleTriggerPress(Action action, bool LockOn)
		{
			GunTemplate.trigger = true;
			GameObject gameObject = new GameObject("Line");
			LineRenderer lineRenderer = gameObject.AddComponent<LineRenderer>();
			lineRenderer.startWidth = 0.035f;
			lineRenderer.endWidth = 0.035f;
			lineRenderer.startColor = GunTemplate.LineColor;
			lineRenderer.endColor = GunTemplate.LineColor;
			lineRenderer.useWorldSpace = true;
			lineRenderer.material = new Material(Shader.Find("GUI/Text Shader"));
			GunTemplate.spherepointer.GetComponent<Renderer>().material.color = GunTemplate.PointerColor;
			if (LockOn)
			{
				bool flag = GunTemplate.LockedPlayer == null;
				if (flag)
				{
					GunTemplate.LockedPlayer = GunTemplate.raycastHit.collider.GetComponentInParent<VRRig>();
				}
				bool flag2 = GunTemplate.LockedPlayer != null;
				if (flag2)
				{
					GunTemplate.spherepointer.transform.position = GunTemplate.LockedPlayer.transform.position;
					action.Invoke();
				}
			}
			else
			{
				action.Invoke();
			}
		}

		// Token: 0x0600000E RID: 14 RVA: 0x00002784 File Offset: 0x00000984
		private static void HandlePcTriggerPress(Action action, bool LockOn, RaycastHit hit)
		{
			GunTemplate.trigger = true;
			GameObject gameObject = new GameObject("Line");
			LineRenderer lineRenderer = gameObject.AddComponent<LineRenderer>();
			lineRenderer.startWidth = 0.035f;
			lineRenderer.endWidth = 0.035f;
			lineRenderer.startColor = GunTemplate.TriggeredLineColor;
			lineRenderer.endColor = GunTemplate.TriggeredLineColor;
			GunTemplate.spherepointer.GetComponent<Renderer>().material.color = GunTemplate.PointerColor;
			if (LockOn)
			{
				bool flag = GunTemplate.LockedPlayer == null;
				if (flag)
				{
					GunTemplate.LockedPlayer = hit.collider.GetComponentInParent<VRRig>();
				}
				bool flag2 = GunTemplate.LockedPlayer != null;
				if (flag2)
				{
					GunTemplate.spherepointer.transform.position = GunTemplate.LockedPlayer.transform.position;
					action.Invoke();
				}
			}
			else
			{
				action.Invoke();
			}
		}

		// Token: 0x0600000F RID: 15 RVA: 0x0000286D File Offset: 0x00000A6D
		private static void DestroyGunObjects()
		{
			Object.Destroy(GunTemplate.spherepointer);
			GunTemplate.spherepointer = null;
			GunTemplate.LockedPlayer = null;
		}

		// Token: 0x04000001 RID: 1
		public static int LineCurve = 30;

		// Token: 0x04000002 RID: 2
		private const float LineWidth = 0.035f;

		// Token: 0x04000003 RID: 3
		private const float LineWidtEnd = 0.055f;

		// Token: 0x04000004 RID: 4
		private const float LineSmoothFactor = 0.5f;

		// Token: 0x04000005 RID: 5
		private const float PointerScale = 0.15f;

		// Token: 0x04000006 RID: 6
		private const float PulseSpeed = 2f;

		// Token: 0x04000007 RID: 7
		private const float PulseAmplitude = 0.03f;

		// Token: 0x04000008 RID: 8
		private const float DestroyDelay = 0.02f;

		// Token: 0x04000009 RID: 9
		public static Color32 PointerColor = ColorLib.SkyBlue;

		// Token: 0x0400000A RID: 10
		public static Color32 LineColor = ColorLib.SkyBlue;

		// Token: 0x0400000B RID: 11
		public static Color32 TriggeredLineColor = ColorLib.SkyBlue;

		// Token: 0x0400000C RID: 12
		public static GameObject spherepointer;

		// Token: 0x0400000D RID: 13
		public static VRRig LockedPlayer;

		// Token: 0x0400000E RID: 14
		public static Vector3 lr;

		// Token: 0x0400000F RID: 15
		public static bool trigger = false;

		// Token: 0x04000010 RID: 16
		public static RaycastHit raycastHit;
	}
}
