using CatLand.Systems.FundamentalSystems.InteractionSystem;
using UnityEngine;
using NaughtyAttributes;

namespace CatLand.Controllers
{
    sealed class DoorController : Interactable
    {
        [SerializeField] private bool m_IsIndoor;
        [SerializeField] private GameObject m_CatGO;
        [SerializeField, EnableIf(nameof(m_IsIndoor))] private Transform m_CatOutsidePosition;
        [SerializeField, DisableIf(nameof(m_IsIndoor))] private Transform m_CatInsidePosition;
        [SerializeField] private GameObject m_HouseInteriorGO;
        [SerializeField] private Animator m_Animator;

        private const string k_Cameras = "Cameras";

        [SerializeField, Foldout(k_Cameras)] private GameObject m_MainCameraGO;
        [SerializeField, Foldout(k_Cameras)] private GameObject m_HouseCameraGO;
        [SerializeField] private Canvas m_Canvas;

        private Camera _mainCamera;
        private Camera _houseCamera;
        private CatInput _catInput;

        private void Awake()
        {
            _mainCamera = m_MainCameraGO.GetComponent<Camera>();
            _houseCamera = m_HouseCameraGO.GetComponent<Camera>();
            _catInput = m_CatGO.GetComponent<CatInput>();
        }

        private void OnEnable() => FadeImageEvents.OnLoadingStarted += OnLoadingStarted;

        private void OnDisable() => FadeImageEvents.OnLoadingStarted -= OnLoadingStarted;

        private void OnDestroy() => FadeImageEvents.OnLoadingStarted -= OnLoadingStarted;

        public override void Interact()
        {
            m_Animator.SetTrigger("OnFadeOut");
        }

        public void OnLoadingStarted()
        {
            if (m_IsIndoor)
            {
                m_HouseCameraGO.SetActive(false);
                m_HouseInteriorGO.SetActive(false);
                m_CatGO.transform.position = m_CatOutsidePosition.position;
                m_MainCameraGO.SetActive(true);
                m_Canvas.worldCamera = _mainCamera;
                _catInput.Camera = _mainCamera;
            }
            else
            {
                m_MainCameraGO.SetActive(false);
                m_HouseInteriorGO.SetActive(true);
                m_HouseCameraGO.SetActive(true);
                m_Canvas.worldCamera = _houseCamera;
                _catInput.Camera = _houseCamera;
                m_CatGO.transform.position = m_CatInsidePosition.position;
            }
        }

        public override string GetDescription()
        {
            return m_IsIndoor ? "Press 'E' to Exit" : "Press 'E' to Enter";
        }
    }
}
