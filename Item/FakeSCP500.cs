using System.Collections.Generic;
using Exiled.API.Features;
using Exiled.API.Features.Spawn;
using Exiled.CustomItems.API.Features;
using Exiled.Events.EventArgs.Map;
using Exiled.Events.EventArgs.Player;
using MEC;
using Mirror;
using UnityEngine;

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
            Exiled.Events.Handlers.Map.PickupAdded += AddGlow;
            Exiled.Events.Handlers.Map.PickupDestroyed += RemoveGlow;
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
        public Color glowColor = new Color32(50, 10, 50 , 150 );
        private Dictionary<Exiled.API.Features.Pickups.Pickup, Exiled.API.Features.Toys.Light> ActiveLights = [];
    
        public void RemoveGlow(PickupDestroyedEventArgs ev)
        {
            if (Check(ev.Pickup))
            {
                if (ev.Pickup != null)
                {
                    if (ev.Pickup?.Base?.gameObject == null) return;
                    if (TryGet(ev.Pickup.Serial, out CustomItem ci) && ci != null)
                    {
                        if (ev.Pickup == null || !ActiveLights.ContainsKey(ev.Pickup)) return;
                        Exiled.API.Features.Toys.Light light = ActiveLights[ev.Pickup];
                        if (light != null && light.Base != null)
                        {
                            NetworkServer.Destroy(light.Base.gameObject);
                        }
                        ActiveLights.Remove(ev.Pickup);
                    }
                }
            }

        }
        public void AddGlow(PickupAddedEventArgs ev)
        {
            if (Check(ev.Pickup) && ev.Pickup.PreviousOwner != null)
            {
                if (ev.Pickup?.Base?.gameObject == null) return;
                TryGet(ev.Pickup, out CustomItem ci);
                Log.Debug($"Pickup is CI: {ev.Pickup.Serial} | {ci.Id} | {ci.Name}");

                var light = Exiled.API.Features.Toys.Light.Create(ev.Pickup.Position);
                light.Color = glowColor;

                light.Intensity = 0.7f;
                light.Range = 0.5f;
                light.ShadowType = LightShadows.None;
                light.Base.gameObject.transform.SetParent(ev.Pickup.Base.gameObject.transform);
                ActiveLights[ev.Pickup] = light;
            }
        }
    }
}

    
