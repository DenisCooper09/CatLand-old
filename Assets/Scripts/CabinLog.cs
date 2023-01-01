using UnityEngine;
using UnityEngine.Events;

public class CabinLog : Interactable
{
    [SerializeField, Range(1, 5)] private int m_RequireCountOfBerries = 3;
    [SerializeField] private ItemData m_BerriesData;
    [SerializeField] private InventoryEngine m_Inventory;
    [SerializeField] private UnityEvent OnGettingRightAmountOfBerries;

    private int _currentAmountOfBerries = 0;

    public override void Interact()
    {
        if (m_Inventory.IsFull == true && m_Inventory.CurrentItem.ItemData.Name == m_BerriesData.Name)
        {
            _currentAmountOfBerries++;
            m_Inventory.RemoveItem();
            if (_currentAmountOfBerries >= m_RequireCountOfBerries)
            {
                OnGettingRightAmountOfBerries?.Invoke();
                Destroy(this);
            }
        }
    }

    public override string GetDescription()
    {
        return $"Berries needed: {_currentAmountOfBerries}/{m_RequireCountOfBerries}";
    }
}
