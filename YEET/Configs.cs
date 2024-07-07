using BepInEx.Configuration;

namespace YEET
{
    internal class Configs
    {
        internal static ConfigEntry<ThrowType> throwTypeConfig;

        internal enum ThrowType
        {
            chargedThrow,
            reverseChargedThrow,
            maxThrow
        }

        internal static void Load(BepinPlugin plugin)
        {
            throwTypeConfig = plugin.Config.Bind("YEET", "ThrowType", ThrowType.reverseChargedThrow);
        }
    }
}
