using UnityEngine;

public class StreetLighting : Interactable
{
    [SerializeField] private GameObject m_LightGO;
    [SerializeField] private Sprite m_Sprite_ON;
    [SerializeField] private Sprite m_Sprite_OFF;

    private SpriteRenderer _spriteRenderer;
    private bool _isOn = true;

    private void Awake()
    {
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    public override void Interact()
    {
        _isOn = !_isOn;
        m_LightGO.SetActive(_isOn);
        _spriteRenderer.sprite = _isOn ? m_Sprite_ON : m_Sprite_OFF;
    }

    public override string GetDescription()
    {
        return _isOn ? "Turn <color=red>Off</color> Street Lighting" : "Turn <color=green>On</color> Street Lighting";
    }
}
