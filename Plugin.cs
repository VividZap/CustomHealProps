using System;
using CustomHealprops.Item;
using Exiled.API.Features;
using Exiled.CustomItems.API;

namespace CustomHealprops
{
    public class Plugin : Plugin<Config>
    {
        public override string Name { get; } = "CustomHealprops";
        public override string Author { get; } = "VividZap";
        public override string Prefix { get; } = "CHP";
        public override Version Version { get; } = new Version(1, 0, 0);
        public override Version RequiredExiledVersion { get; } =  new Version(9, 12, 1);
        public static Plugin Instance { get; private set; }
        
        public override void OnEnabled()
        {
            new Drugs().Register();
            new FakeSCP500().Register();
            new EnhancedSCP500().Register();
            new AdrenalineI().Register();
            new AdrenalineII().Register();
            Log.Debug($"{nameof(Plugin) } is enabled.");
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            Log.Debug($"{nameof(Plugin)} is disabled.");
            base.OnDisabled();
        }
    }
}