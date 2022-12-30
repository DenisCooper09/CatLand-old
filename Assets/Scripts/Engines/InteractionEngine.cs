using System;
using UnityEngine;
using UnityEngine.UI;
using NaughtyAttributes;
using TMPro;

public sealed class InteractionEngine : CollisionDetector
{
    [SerializeField] private bool m_DrawGizmos;
    [SerializeField] private KeyCode m_InteractionKey = KeyCode.E;

    private const string OverlapCircle = "Overlap Circle";

    [SerializeField, BoxGroup(OverlapCircle)] private LayerMask m_InteractionLayer;
    [SerializeField, BoxGroup(OverlapCircle), Min(0)] private float m_InteractionRadius = 0.45f;
    [SerializeField, BoxGroup(OverlapCircle)] private Transform m_OverlapCirclePoint;

    private const string UI = nameof(UI);

    [SerializeField, Foldout(UI)] private TextMeshProUGUI m_InteractionHeader;
    [SerializeField, Foldout(UI)] private Image m_ProgressBar;
    [SerializeField, Foldout(UI)] private GameObject m_ProgressBarGO;

    private Interactable _interactable;
    private bool _haveInteraction;

    private void Update()
    {
        if (_haveInteraction)
            HandleInteraction(_interactable);
    }

    private void FixedUpdate()
    {
        SearchForAvailableInteraction();
    }

    private void SearchForAvailableInteraction()
    {
        Collider2D detectedCollider = GetDetectedCollider(m_OverlapCirclePoint.position, m_InteractionRadius, m_InteractionLayer);

        if (detectedCollider != null && detectedCollider.TryGetComponent(out _interactable))
        {
            _haveInteraction = true;
            m_InteractionHeader.text = _interactable.GetDescription();
            m_ProgressBarGO.SetActive(_interactable.InteractionType == Interactable.InteractionTypeEnum.Hold);
            return;
        }
        else m_InteractionHeader.text = string.Empty;

        if (_haveInteraction)
            UndoHavingInteraction();
    }

    private void OnDrawGizmosSelected()
    {
        if (!m_DrawGizmos) return;
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(m_OverlapCirclePoint.position, m_InteractionRadius);
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
        if (_interactable != null) _interactable.ResetHoldTime();
        m_ProgressBar.fillAmount = 0f;
    }
}
