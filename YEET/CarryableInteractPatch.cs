using HarmonyLib;
using UnityEngine;

namespace YEET
{
    [HarmonyPatch(typeof(CarryableInteract))]
    internal class CarryableInteractPatch
    {
        [HarmonyPostfix]
        [HarmonyPatch("StartThrow")]
        static void StartThrow(ref float ___throwStartTime, float ___maxThrowDuration)
        {
            if (Configs.throwTypeConfig.Value == Configs.ThrowType.maxThrow)
            {
                ___throwStartTime -= ___maxThrowDuration;
            }
        }

        [HarmonyPrefix]
        [HarmonyPatch("DelayedEndThrow")]
        static void DelayedEndThrow(ref float ___throwStartTime, float ___maxThrowDuration)
        {
            if (Configs.throwTypeConfig.Value == Configs.ThrowType.reverseChargedThrow)
            {
                float duration = Mathf.Clamp(Time.time - ___throwStartTime, 0f, ___maxThrowDuration);
                duration = ___maxThrowDuration - duration;
                ___throwStartTime = Time.time - duration;
            }
        }

        [HarmonyPrefix]
        [HarmonyPatch("Update")]
        static void UpdatePrefix(bool ____isChargingThrow, ref float ___throwStartTime, float ___maxThrowDuration, out float __state)
        {
            __state = ___throwStartTime;
            if (____isChargingThrow && Configs.throwTypeConfig.Value == Configs.ThrowType.reverseChargedThrow)
            {
                float duration = Mathf.Clamp01((Time.time - ___throwStartTime) / ___maxThrowDuration);
                duration = 1 - duration;
                ___throwStartTime = Time.time - (duration * ___maxThrowDuration);
            }
        }

        [HarmonyPostfix]
        [HarmonyPatch("Update")]
        static void UpdatePostfix(bool ____isChargingThrow, ref float ___throwStartTime, float __state)
        {
            if (____isChargingThrow && Configs.throwTypeConfig.Value == Configs.ThrowType.reverseChargedThrow)
            {
                ___throwStartTime = __state;
            }
        }
    }
}
