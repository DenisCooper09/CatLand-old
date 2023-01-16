using CatLand.Systems.FundamentalSystems.InteractionSystem;
using UnityEngine;

namespace CatLand
{
    sealed class ToggleLighting : Interactable
    {
        [SerializeField] private GameObject m_LightGO;
        [SerializeField] private Sprite m_Sprite_ON;
        [SerializeField] private Sprite m_Sprite_OFF;

        private bool _isOn = true;

        public override void Interact()
        {
            _isOn = !_isOn;
            m_LightGO.SetActive(_isOn);
            SpriteRenderer.sprite = _isOn ? m_Sprite_ON : m_Sprite_OFF;
        }

        public override string GetDescription()
        {
            return _isOn ? "Turn <color=red>Off</color>" : "Turn <color=green>On</color>";
        }
    }
}
