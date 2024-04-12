using System;
using UnityModManagerNet;
using HarmonyLib;
using System.Reflection;

namespace MasterMechanicMod
{
    public class Main
    {
        public static bool enabled;

        static bool Load(UnityModManager.ModEntry modEntry)
        {
            modEntry.OnToggle = new Func<UnityModManager.ModEntry, bool, bool>(Main.OnToggle);

            Harmony harmony = new Harmony(modEntry.Info.Id);

            // patching the current assembly
            var curAssembly = Assembly.GetExecutingAssembly();
            harmony.PatchAll(curAssembly);
            return true;
        }

        static bool OnToggle(UnityModManager.ModEntry modEntry, bool value)
        {
            if(value == true)
            {
                modEntry.Logger.Log("Master Mechanic Mod On");
            }
            else
            {
                modEntry.Logger.Log("Master Mechanic Mod Off");
            }

            enabled = value;
            return true;
        }
    }
}
