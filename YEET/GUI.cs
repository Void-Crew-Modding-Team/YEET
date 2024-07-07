using VoidManager.CustomGUI;
using VoidManager.Utilities;

namespace YEET
{
    internal class GUI : ModSettingsMenu
    {
        public override string Name() => "YEET";

        public override void Draw()
        {
            bool type = Configs.throwTypeConfig.Value == Configs.ThrowType.chargedThrow;
            if (GUITools.DrawCheckbox("Charged throw", ref type))
            {
                Configs.throwTypeConfig.Value = Configs.ThrowType.chargedThrow;
            }
            type = Configs.throwTypeConfig.Value == Configs.ThrowType.reverseChargedThrow;
            if (GUITools.DrawCheckbox("Reverse-charged throw", ref type))
            {
                Configs.throwTypeConfig.Value = Configs.ThrowType.reverseChargedThrow;
            }
            type = Configs.throwTypeConfig.Value == Configs.ThrowType.maxThrow;
            if (GUITools.DrawCheckbox("YEET", ref type))
            {
                Configs.throwTypeConfig.Value = Configs.ThrowType.maxThrow;
            }
        }
    }
}
