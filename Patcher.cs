using System;
using System.Collections.Generic;
using System.Text;
using HarmonyLib;
using UnityEngine;

namespace BigZoom
{
	class CameraZoomPatch
	{
		[HarmonyPatch(typeof(CameraController), "Awake")]
		[HarmonyPrefix]
		static void Prefix(CameraController __instance)
		{
			Camera targetCamera = Traverse.Create(__instance).Field("targetCamera").GetValue<Camera>();
			targetCamera.farClipPlane = 10000f;
			Traverse.Create(__instance).Field("targetCamera").SetValue(targetCamera);

			Traverse.Create(__instance).Field("maxCameraDist").SetValue(10000f);
		}
	}

	class CameraResetPatch
	{
		[HarmonyPatch(typeof(CameraController), "Update")]
		[HarmonyPostfix]
		static void Postfix(CameraController __instance)
		{
			if (UnityEngine.InputSystem.Keyboard.current.rKey.wasPressedThisFrame)
			{ 
				__instance.SetDistance(70);
			}
		}
	}
}
