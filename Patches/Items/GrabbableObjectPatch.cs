using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;

namespace DeathShovel.Patches.Items
{
    // Patch GrabbableObject because it is the base class for a shovel
    [HarmonyPatch(typeof(GrabbableObject), "Start")]
    internal class GrabbableObjectPatch
    {
        // Patch start so that we can set shovelHitForce to 3 (instakill on killable entities)
        public static void Prefix(GrabbableObject __instance)
        {
            // Only run if the instance is a shovel
            if (__instance.GetType() == typeof(Shovel))
            {
                Shovel shovel = __instance as Shovel;
                shovel.shovelHitForce = 3;
            }
        }
    }

    [HarmonyPatch(typeof(Shovel), "SwingShovel")]
    internal class ShovelPatch
    {
        public static void Prefix(Shovel __instance, bool cancel = false)
        {
            Plugin.Log.LogInfo(__instance.shovelHitForce);
        }
    }
}
