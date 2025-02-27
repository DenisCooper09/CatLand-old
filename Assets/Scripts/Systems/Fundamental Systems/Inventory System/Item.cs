using CatLand.Systems.FundamentalSystems.InteractionSystem;
using CatLand.ScriptableObjects;
using System;
using UnityEngine;

namespace CatLand.Systems.FundamentalSystems.InventorySystem
{
    sealed class Item : Interactable
    {
        public static event Action<Item> OnPickup;

        [field: SerializeField]
        public ItemData ItemData { get; private set; }
        public GameObject ItemObject { get => gameObject; }

        public override string GetDescription()
        {
            return ItemData.Name;
        }

        public override void Interact()
        {
            OnPickup?.Invoke(this);
        }
    }
}
