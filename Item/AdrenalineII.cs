using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.API.Features.Spawn;
using Exiled.CustomItems.API.Features;
using Exiled.Events.EventArgs.Player;
using MEC;

namespace CustomHealprops.Item
{
    public class AdrenalineII : CustomItem
    {
        public override uint Id { get; set; } = 5;
        public override string Name { get; set; } =  "AdrenalineII";
        public override string Description { get; set; }
        public override float Weight { get; set; } = 1.5f;
        public override ItemType Type { get; set; } = ItemType.Adrenaline;
        public override SpawnProperties SpawnProperties { get; set; }
        
        protected override void SubscribeEvents()
        {
            Exiled.Events.Handlers.Player.UsedItem += OnUseAdrenalineII;
            Log.Debug("AdrenalineII subscribed");
            base.SubscribeEvents();
        }

        protected override void UnsubscribeEvents()
        {
            Log.Debug("AdrenalineII unsubscribed");
            base.UnsubscribeEvents();
        }

        private void OnUseAdrenalineII(UsedItemEventArgs eventArgs)
        {
            Check(eventArgs.Player.CurrentItem);
            eventArgs.Player.EnableEffect(EffectType.MovementBoost, 60, 4);
            eventArgs.Player.AddAhp(20f);
            eventArgs.Player.Heal(+5);
            eventArgs.Player.ShowHint(Plugin.Instance.Config.AdrenalineIIHint , 4);
            Log.Info($"{eventArgs.Player} Used item {eventArgs.Player.CurrentItem} in time : {Timing.DeltaTime} in place {eventArgs.Player.CurrentRoom}");
        }
    }
}