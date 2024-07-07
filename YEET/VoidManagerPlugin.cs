using VoidManager.MPModChecks;

namespace YEET
{
    public class VoidManagerPlugin : VoidManager.VoidPlugin
    {
        public override MultiplayerType MPType => MultiplayerType.Client;

        public override string Author => "18107";

        public override string Description => "Throw all items with maximum force without charging the throw";
    }
}
