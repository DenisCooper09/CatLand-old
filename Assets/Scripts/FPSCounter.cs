using UnityEngine;
using TMPro;

namespace CatLand
{
    sealed class FPSCounter : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI m_FPSText;
        [SerializeField] private float m_HUDRefreshRate = 1f;

        private float _timer;
        private bool _active;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                _active = !_active;
                if (!_active)
                    m_FPSText.text = string.Empty;
            }

            if (!_active)
                return;

            if (Time.unscaledTime > _timer)
            {
                int fps = (int)(1f / Time.unscaledDeltaTime);
                m_FPSText.text = $"{fps} FPS";
                _timer = Time.unscaledTime + m_HUDRefreshRate;
            }
        }
    }
}
