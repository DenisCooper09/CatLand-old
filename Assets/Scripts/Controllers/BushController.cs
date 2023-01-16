using CatLand.Systems.FundamentalSystems.InteractionSystem;
using CatLand.ScriptableObjects;
using UnityEngine;

namespace CatLand.Controllers
{
    sealed class BushController : Interactable
    {
        [SerializeField] private Transform m_BerriesSpawnPoint;
        [SerializeField] private ItemData m_BerriesItemData;
        [SerializeField] private Sprite m_BushWithoutBerries;

        public override void Interact()
        {
            Instantiate(m_BerriesItemData.Object, m_BerriesSpawnPoint.position, Quaternion.identity);
            SpriteRenderer.sprite = m_BushWithoutBerries;
            UndoOutline();
            Destroy(this);
        }

        public override string GetDescription()
        {
            return "Bush";
        }
    }
}
