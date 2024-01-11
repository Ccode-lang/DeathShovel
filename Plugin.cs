using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LethalConfig;
using BepInEx.Configuration;
using LethalConfig.ConfigItems.Options;
using LethalConfig.ConfigItems;

namespace DeathShovel
{
    [BepInPlugin(MyGuid, PluginName, VersionString)]
    [BepInDependency("ainavt.lc.lethalconfig")]
    public class Plugin : BaseUnityPlugin
    {
        private const string MyGuid = "Ccode.DeathShovel";
        private const string PluginName = "DeathShovel";
        private const string VersionString = "0.0.1";

        public static ConfigEntry<int> config;

        private static readonly Harmony Harmony = new Harmony(MyGuid);

        public static ManualLogSource Log;
        public void Awake()
        {
            config = Config.Bind("General", "ConfigShovel", 3, "The force value of a shovel.");
            var slider = new IntSliderConfigItem(config, new IntSliderOptions
            {
                Min = 0,
                Max = 100
            });
            Harmony.PatchAll();
            Logger.LogInfo(PluginName + " " + VersionString + " " + "loaded.");
            Log = Logger;
        }
    }
}
