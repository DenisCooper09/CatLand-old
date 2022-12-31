using UnityEngine;
using NaughtyAttributes;

[CreateAssetMenu(fileName = "ItemData_", menuName = "Scriptable Objects/Item", order = 1)]
public class ItemData : ScriptableObject
{
    [field: SerializeField]
    public string Name { get; private set; }

    [field: SerializeField]
    public Sprite Icon { get; private set; } = null;

    [field: SerializeField, ShowAssetPreview(128, 128)]
    public GameObject Object { get; private set; } = null;
}
