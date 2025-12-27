using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.API.Features.Spawn;
using Exiled.CustomItems.API.Features;
using Exiled.Events.EventArgs.Player;
using MEC;

namespace CustomHealprops.Item
{
    public class EnhancedSCP500 : CustomItem
    {
        public override uint Id { get; set; } = 3;
        public override string Name { get; set; } = "EnhancedSCP500";
        public override string Description { get; set; }
        public override float Weight { get; set; } = 1.5f;
        public override ItemType Type { get; set; } = ItemType.SCP500;
        public override SpawnProperties SpawnProperties { get; set; }
        
        protected override void SubscribeEvents()
        {
            Exiled.Events.Handlers.Player.UsedItem += OnUsedEnhancedSCP500;
            Log.Debug("Subscribed");
            base.SubscribeEvents();
        }

        protected override void UnsubscribeEvents()
        {
            Exiled.Events.Handlers.Player.UsedItem -= OnUsedEnhancedSCP500;
            Log.Debug("Unsubscribed");
            base.UnsubscribeEvents();
        }

        private void OnUsedEnhancedSCP500(UsedItemEventArgs eventArgs)
        {
            Check(eventArgs.Player.CurrentItem);
            eventArgs.Player.EnableEffects(new[] { EffectType.MovementBoost, EffectType.Ghostly } , 4 );
            eventArgs.Player.ShowHint(Plugin.Instance.Config.EnhancedSCP500Hint);
            Log.Info($"{eventArgs.Player} Used item {eventArgs.Player.CurrentItem} in time : {Timing.DeltaTime} in place {eventArgs.Player.CurrentRoom}");
        }
    }
}