using Exiled.API.Features;
using Exiled.API.Features.Spawn;
using Exiled.CustomItems.API.Features;
using Exiled.Events.EventArgs.Player;
using MEC;

namespace CustomHealprops.Item
{
    public class FakeSCP500 : CustomItem
    {
        public override uint Id { get; set; } = 2;
        public override string Name { get; set; } = "FakeSCP500";
        public override string Description { get; set; }
        public override float Weight { get; set; } = 1.5f;
        public override ItemType Type { get; set; } = ItemType.SCP500;
        public override SpawnProperties SpawnProperties { get; set; }
        
        protected override void SubscribeEvents()
        {
            Exiled.Events.Handlers.Player.UsedItem += OnUsedFakeSCP500;
            Log.Debug($"{nameof(FakeSCP500)} subscribed.");
            base.SubscribeEvents();
        }

        protected override void UnsubscribeEvents()
        {
            Exiled.Events.Handlers.Player.UsedItem -= OnUsedFakeSCP500;
            Log.Debug($"{nameof(FakeSCP500)} unsubscribed.");
            base.UnsubscribeEvents();
        }

        private void OnUsedFakeSCP500(UsedItemEventArgs eventArgs)
        {
            Check(eventArgs.Player.CurrentItem);
            {
                eventArgs.Player.Health = -15f;
                eventArgs.Player.ShowHint(Plugin.Instance.Config.FakeSCP500Hint , 4);
                Log.Info($"{eventArgs.Player} Used item {eventArgs.Player.CurrentItem} in time : {Timing.DeltaTime} in place {eventArgs.Player.CurrentRoom}");
            }
        }
    }
}