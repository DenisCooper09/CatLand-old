using CatLand.Systems.FundamentalSystems.InteractionSystem;
using UnityEngine;
using UnityEngine.Rendering;

namespace CatLand.Controllers
{
    sealed class ComputerController : Interactable
    {
        [SerializeField] private GameObject m_ConsoleUI;
        [SerializeField] private Volume m_Volume;
        [SerializeField] private VolumeProfile m_DefaultVolumeProfile;
        [SerializeField] private VolumeProfile m_ConsoleVolumeProfile;

        public override void Interact()
        {
            base.Interact();
            m_ConsoleUI.SetActive(true);
            SetConsoleVolumeProfile();
        }

        public override string GetDescription()
        {
            return "Computer";
        }

        public void SetConsoleVolumeProfile()
        {
            m_Volume.profile = m_ConsoleVolumeProfile;
        }

        public void ResetVolumeProfile()
        {
            m_Volume.profile = m_DefaultVolumeProfile;
        }
    }
}
