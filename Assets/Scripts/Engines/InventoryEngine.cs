using UnityEngine;
using UnityEngine.UI;
using TMPro;

public sealed class InventoryEngine : MonoBehaviour
{
    public Item CurrentItem { get; private set; }

    public bool IsFull { get; private set; }

    [SerializeField] private Transform m_DropPoint;
    [SerializeField] private GameObject m_InventoryGO;
    [SerializeField] private TextMeshProUGUI m_ItemNameText;
    [SerializeField] private Image m_ItemIcon;

    private void OnEnable() => Item.OnPickup += Pickup;

    private void OnDisable() => Item.OnPickup -= Pickup;

    private void OnDestroy() => Item.OnPickup -= Pickup;

    private void Pickup(Item item)
    {
        AddItem(item);
        Destroy(item.ItemObject);
    }

    public void AddItem(Item item)
    {
        if (IsFull)
            return;

        IsFull = true;
        CurrentItem = item;
        m_ItemNameText.text = item.ItemData.Name;
        m_ItemIcon.sprite = item.ItemData.Icon;
        m_InventoryGO.SetActive(true);
    }

    public void Drop()
    {
        RemoveItem();
        Instantiate(CurrentItem.ItemData.Object, m_DropPoint.position, Quaternion.identity);
    }

    public void RemoveItem()
    {
        if (!IsFull)
            return;

        IsFull = false;
        m_InventoryGO.SetActive(false);
    }
}
