using UnityEngine;

public sealed class Bush : Interactable
{
    [SerializeField] private Transform m_BerriesSpawnPoint;
    [SerializeField] private ItemData m_BerriesItemData;
    [SerializeField] private Sprite m_BushWithoutBerries;

    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    public override void Interact()
    { 
        Instantiate(m_BerriesItemData.Object, m_BerriesSpawnPoint.position, Quaternion.identity);
        _spriteRenderer.sprite = m_BushWithoutBerries;
        Destroy(this);
    }

    public override string GetDescription()
    {
        return nameof(Bush);
    }
}
