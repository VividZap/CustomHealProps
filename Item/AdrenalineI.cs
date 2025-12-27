using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.API.Features.Spawn;
using Exiled.CustomItems.API.Features;
using Exiled.Events.EventArgs.Player;
using MEC;

namespace CustomHealprops.Item
{
    public class AdrenalineI : CustomItem
    {
        public override uint Id { get; set; } = 4;
        public override string Name { get; set; } = "AdrenalineI";
        public override string Description { get; set; }
        public override float Weight { get; set; } = 1.5f;
        public override ItemType Type { get; set; } = ItemType.Adrenaline;
        public override SpawnProperties SpawnProperties { get; set; }

        protected override void SubscribeEvents()
        {
            Exiled.Events.Handlers.Player.UsedItem += OnUsedAdrenalineI;
            Log.Debug("Subscribed");
            base.SubscribeEvents();
        }

        protected override void UnsubscribeEvents()
        {
            Exiled.Events.Handlers.Player.UsedItem -= OnUsedAdrenalineI;
            Log.Debug("Unsubscribed");
            base.UnsubscribeEvents();
        }

        private void OnUsedAdrenalineI(UsedItemEventArgs eventArgs)
        {
            Check(eventArgs.Player.CurrentItem);
            eventArgs.Player.EnableEffect(EffectType.MovementBoost, 50, 5);
            eventArgs.Player.ShowHint(Plugin.Instance.Config.AdrenalineIHint);
            Log.Info($"{eventArgs.Player} Used item {eventArgs.Player.CurrentItem} in time : {Timing.DeltaTime} in place {eventArgs.Player.CurrentRoom}");
        }
    }
}