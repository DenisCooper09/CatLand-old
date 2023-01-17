using CatLand.Systems.FundamentalSystems.InteractionSystem;
using CatLand.Systems.FundamentalSystems.InventorySystem;
using CatLand.ScriptableObjects;
using UnityEngine;

namespace CatLand
{
    sealed class ComputerFixer : Interactable
    {
        [SerializeField] private ItemData m_CPUItemData;
        [SerializeField] private InventorySystem m_Inventory;
        [SerializeField] private GameObject m_ComputerControllerGO;

        public override void Interact()
        {
            if (m_Inventory.IsFull && m_Inventory.CurrentItem.ItemData.Name == m_CPUItemData.Name)
            {
                base.Interact();
                m_Inventory.RemoveItem();
                m_ComputerControllerGO.SetActive(true);
                Destroy(gameObject);
            }
        }

        public override string GetDescription()
        {
            return "Computer Needs CPU";
        }
    }
}
