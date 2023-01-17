using UnityEngine;
using NaughtyAttributes;

namespace CatLand.Systems.FundamentalSystems.InteractionSystem
{
    abstract class Selectable : MonoBehaviour
    {
        [SerializeField] protected SpriteRenderer SpriteRenderer;

        private const string k_Materials = "Materials";

        [SerializeField, Foldout(k_Materials)] private Material m_DefaultMaterial;
        [SerializeField, Foldout(k_Materials)] private Material m_OutlineMaterial;

        private bool _isOutlined;

        private void Awake()
        {
            UndoOutline();
        }

        public void Outline()
        {
            if (_isOutlined || SpriteRenderer == null)
                return;

            _isOutlined = true;
            SpriteRenderer.material = m_OutlineMaterial;
        }

        public void UndoOutline()
        {
            if (!_isOutlined || SpriteRenderer == null)
                return;

            _isOutlined = false;
            SpriteRenderer.material = m_DefaultMaterial;
        }

        public abstract string GetDescription();
    }
}
