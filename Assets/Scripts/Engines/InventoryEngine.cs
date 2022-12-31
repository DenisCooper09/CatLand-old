using UnityEngine;
using UnityEngine.UI;
using TMPro;

public sealed class InventoryEngine : MonoBehaviour
{
    [SerializeField] private Transform m_DropPoint;
    [SerializeField] private GameObject m_InventoryGO;
    [SerializeField] private TextMeshProUGUI m_ItemNameText;
    [SerializeField] private Image m_ItemIcon;

    private Item _currentItem;
    private bool _isFull;

    private void OnEnable() => Item.OnPickup += Pickup;

    private void OnDisable() => Item.OnPickup -= Pickup;

    private void OnDestroy() => Item.OnPickup -= Pickup;

    private void Pickup(Item item)
    {
        if (_isFull)
            return;

        _isFull = true;
        _currentItem = item;
        m_ItemNameText.text = item.ItemData.Name;
        m_ItemIcon.sprite = item.ItemData.Icon;
        m_InventoryGO.SetActive(true);
        Destroy(item.ItemObject);
    }

    public void Drop()
    {
        if (!_isFull)
            return;

        _isFull = false;
        Instantiate(_currentItem.ItemData.Object, m_DropPoint.position, Quaternion.identity);
        m_InventoryGO.SetActive(false);
    }
}
