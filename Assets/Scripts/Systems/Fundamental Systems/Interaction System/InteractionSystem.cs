using System;
using UnityEngine;
using UnityEngine.UI;
using NaughtyAttributes;
using TMPro;

namespace CatLand.Systems.FundamentalSystems.InteractionSystem
{
    sealed class InteractionSystem : MonoBehaviour
    {
        [SerializeField] private bool m_DrawGizmos;
        [SerializeField] private KeyCode m_InteractionKey = KeyCode.E;

        private const string OverlapCircle = "Overlap Circle";

        [SerializeField, BoxGroup(OverlapCircle)] private LayerMask m_InteractionLayer;
        [SerializeField, BoxGroup(OverlapCircle), Min(0)] private float m_InteractionRadius = 0.45f;
        [SerializeField, BoxGroup(OverlapCircle)] private Transform m_OverlapCirclePoint;

        private const string k_UI = "UI";

        [SerializeField, Foldout(k_UI)] private TextMeshProUGUI m_InteractionHeader;
        [SerializeField, Foldout(k_UI)] private Animator m_InteractionHeaderAnimator;
        [SerializeField, Foldout(k_UI)] private Image m_ProgressBar;
        [SerializeField, Foldout(k_UI)] private GameObject m_ProgressBarGO;

        private Selectable _lastSelectedColliderSelectable;
        private Interactable _lastSelectedColliderInteractable;
        private bool _haveInteraction;
        private bool _showText;

        public void ResetShowText() => _showText = false;

        private void Update()
        {
            if (_haveInteraction)
                HandleInteraction(_lastSelectedColliderInteractable);
        }

        private void FixedUpdate()
        {
            SearchForAvailableInteraction();
        }

        private void SearchForAvailableInteraction()
        {
            Collider2D selectedCollider = Physics2D.OverlapCircle(
                m_OverlapCirclePoint.position,
                m_InteractionRadius,
                m_InteractionLayer);

            if (selectedCollider != null &&
                selectedCollider.gameObject.TryGetComponent(out Selectable selectable))
            {
                if (_lastSelectedColliderSelectable != null)
                    _lastSelectedColliderSelectable.UndoOutline();
                selectable.Outline();

                _lastSelectedColliderSelectable = selectable;

                _showText = true;
                m_InteractionHeader.text = _lastSelectedColliderSelectable.GetDescription();
                m_InteractionHeaderAnimator.SetBool("TextOut", true);

                if (selectedCollider != null &&
                    selectedCollider.gameObject.TryGetComponent(out Interactable interactable))
                {
                    _haveInteraction = true;

                    if (_lastSelectedColliderInteractable != null)
                        _lastSelectedColliderInteractable.UndoOutline();
                    interactable.Outline();

                    _lastSelectedColliderInteractable = interactable;

                    m_ProgressBarGO.SetActive(
                        _lastSelectedColliderInteractable.InteractionType is Interactable.InteractionTypeEnum.Hold);
                    return;
                }
            }
            else
            {
                if (_lastSelectedColliderSelectable != null)
                    _lastSelectedColliderSelectable.UndoOutline();

                if (_lastSelectedColliderInteractable != null)
                    _lastSelectedColliderInteractable.UndoOutline();

                m_InteractionHeader.text ??= _showText ? string.Empty : _lastSelectedColliderSelectable.GetDescription(); 
                m_InteractionHeaderAnimator.SetBool("TextOut", false);
                UndoHavingInteraction();
            }
        }

        private void HandleInteraction(Interactable interactable)
        {
            switch (interactable.InteractionType)
            {
                case Interactable.InteractionTypeEnum.Click:
                    if (Input.GetKeyDown(m_InteractionKey))
                    {
                        interactable.Interact();
                        UndoHavingInteraction();
                    }
                    break;
                case Interactable.InteractionTypeEnum.Hold:
                    if (Input.GetKey(m_InteractionKey))
                    {
                        interactable.IncreaseHoldTime();
                        if (interactable.GetHoldTime() > interactable.InteractionDuration)
                        {
                            interactable.Interact();
                            interactable.ResetHoldTime();
                            UndoHavingInteraction();
                        }
                    }
                    else if (interactable.GetHoldTime() > 0f)
                    {
                        interactable.DecreaseHoldTime();
                    }

                    m_ProgressBar.fillAmount = interactable.GetHoldTime() / interactable.InteractionDuration;
                    break;
                default:
                    throw new Exception("Unsupported type of interactable.");
            }
        }

        private void UndoHavingInteraction()
        {
            _haveInteraction = false;
            m_ProgressBar.fillAmount = 0f;
            if (_lastSelectedColliderInteractable != null)
                _lastSelectedColliderInteractable.ResetHoldTime();
        }

        private void OnDrawGizmosSelected()
        {
            if (!m_DrawGizmos) return;
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(m_OverlapCirclePoint.position, m_InteractionRadius);
        }
    }
}
