using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;

namespace DeathShovel.Patches.Items
{
    [HarmonyPatch(nameof(GrabbableObject))]
    internal class GrabbableObjectPatch
    {
        [HarmonyPatch(nameof(GrabbableObject.Start))]
        public static void Start_Prefix(GrabbableObject __instance)
        {
            if (__instance.GetType() == typeof(Shovel))
            {
                Shovel shovel = __instance as Shovel;
                shovel.shovelHitForce = 4;
            }
        }
    }
}
