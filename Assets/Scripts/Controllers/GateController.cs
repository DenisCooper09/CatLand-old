using CatLand.Systems.FundamentalSystems.InteractionSystem;
using CatLand.Systems.ConsoleSystem;
using UnityEngine;

namespace CatLand.Controllers
{
    sealed class GateController : Interactable
    {
        public int GateIndex { get; set; }

        [SerializeField] private GateIndexesController m_GateIndexesController;
        [SerializeField] private ConsoleSystem m_ConsoleSystem;

        private bool _isActive;

        public override void Interact()
        {
            base.Interact();
            _isActive = !_isActive;
            m_ConsoleSystem.ProtectedCommands[GateIndex].IsBlocked = !_isActive;
        }

        public override string GetDescription()
        {
            return _isActive ? "<color=green>Gate</color>" : "<color=red>Gate</color>";
        }

        public void Destroy() 
        {
            m_GateIndexesController.RemoveGate(GateIndex);
            Destroy(gameObject);
        }
    }
}
