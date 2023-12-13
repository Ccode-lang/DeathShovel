using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameNetcodeStuff;
using HarmonyLib;

namespace DeathShovel.Patches.Enemy
{
    [HarmonyPatch(typeof(SandSpiderAI), "HitEnemy")]
    internal class SandSpiderAIPatch
    {
        public static void Prefix(ref int ___health, int force, PlayerControllerB playerWhoHit, bool playHitSFX)
        {
            ___health = ___health - force + 1;
        }

        public static void Postfix(ref int ___health)
        {
            Plugin.Log.LogInfo(___health);
        }
    }
}
