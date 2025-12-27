using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.API.Features.Spawn;
using Exiled.CustomItems.API.Features;
using Exiled.Events.EventArgs.Player;
using MEC;

namespace CustomHealprops.Item
{
    public class Drugs : CustomItem
    {
        public override uint Id { get; set; } = 1;
        public override string Name { get; set; } = "Drugs";
        public override string Description { get; set; }
        public override float Weight { get; set; } = 1f;
        public override ItemType Type { get; set; } = ItemType.Painkillers;
        public override SpawnProperties SpawnProperties { get; set; }
        
        protected override void SubscribeEvents()
        {
            Exiled.Events.Handlers.Player.UsedItem += OnUsedItem;
            Log.Debug($"{nameof(Drugs)} subscribed.");
            base.SubscribeEvents();
        }

        protected override void UnsubscribeEvents()
        {
            Exiled.Events.Handlers.Player.UsedItem -= OnUsedItem;
            Log.Debug($"{nameof(Drugs)} unsubscribed.");
            base.UnsubscribeEvents();
        }

        private void OnUsedItem(UsedItemEventArgs eventArgs)
        {
            Check(eventArgs.Player.CurrentItem);
            {
                eventArgs.Player.EnableEffect(EffectType.Bleeding, 5f);
                eventArgs.Player.ShowHint(Plugin.Instance.Config.DrugHint , 4);
                Log.Debug($"{nameof(Drugs)} used {eventArgs.Player.CurrentItem}.");
                Log.Info($"{eventArgs.Player} Used item {eventArgs.Player.CurrentItem} in time : {Timing.DeltaTime} in place {eventArgs.Player.CurrentRoom}");
            }
        }
    }
}