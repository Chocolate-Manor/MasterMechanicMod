using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HarmonyLib;
using UnityEngine;

namespace MasterMechanicMod.Patches
{
    [HarmonyPatch(typeof(ShadersBackup), nameof(ShadersBackup.Backup))]
    class ShadersBackupPatch
    {
        static void Postfix(GameObject go)
        {
            if (!Main.enabled) return;

            Renderer component = go.GetComponent<Renderer>();
            if (component == null)
            {
                return;
            }
            component.enabled = false;
        }
    }

    [HarmonyPatch(typeof(ShadersBackup), nameof(ShadersBackup.RevertToBackup))]
    class ShadersRevertToBackupPatch
    {
        static void Postfix(GameObject go)
        {
            if (!Main.enabled) return;

            Renderer component = go.GetComponent<Renderer>();
            if (component == null)
            {
                return;
            }
            component.enabled = true;
        }
    }
}
