using BepInEx;
using HarmonyLib;

namespace BigZoom
{
    [BepInPlugin("Rice.Mods.BigZoom", "Big Zoom", "1.0.0.0")]
    public class Plugin : BaseUnityPlugin
    {
		public Harmony harmonyMain;

        private void Awake()
        {
			harmonyMain = new Harmony(PluginInfo.PLUGIN_GUID);
			harmonyMain.PatchAll(typeof(CameraZoomPatch));
			harmonyMain.PatchAll(typeof(CameraResetPatch));
        }
    }
}
