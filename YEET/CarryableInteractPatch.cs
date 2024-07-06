using HarmonyLib;

namespace Yeet
{
    [HarmonyPatch(typeof(CarryableInteract))]
    internal class CarryableInteractPatch
    {
        [HarmonyPostfix]
        [HarmonyPatch("StartThrow")]
        static void StartThrow(ref float ___throwStartTime, float ___maxThrowDuration)
        {
            ___throwStartTime -= ___maxThrowDuration;
        }
    }
}
