using CatLand.Systems.FundamentalSystems.InteractionSystem;
using UnityEngine;
using NaughtyAttributes;
using TMPro;

namespace CatLand.Controllers
{
    sealed class LetterController : Interactable
    {
        [SerializeField] private string m_Header;
        [SerializeField, ResizableTextArea] private string m_MainText;
        [SerializeField] private GameObject m_InformationGO;
        [SerializeField] private GameObject m_SystemsGO;
        [SerializeField] private MonoBehaviour m_CatInput;
        [SerializeField] private TextMeshProUGUI m_HeaderText;
        [SerializeField] private TextMeshProUGUI m_Text;

        private bool _active;

        public override void Interact()
        {
            _active = !_active;
            m_InformationGO.SetActive(_active);
            m_SystemsGO.SetActive(!_active);
            m_CatInput.enabled = !_active;
            if (_active)
            {
                m_HeaderText.text = m_Header;
                m_Text.text = m_MainText;
            }
        }

        public override string GetDescription()
        {
            return "Letter";
        }
    }
}
