using UnityEngine;
using NaughtyAttributes;

public abstract class Interactable : MonoBehaviour
{
    public enum InteractionTypeEnum { Click, Hold }

    [field: SerializeField]
    public InteractionTypeEnum InteractionType { get; private set; }

    [field: SerializeField, ShowIf(nameof(Enabled))]
    public float InteractionDuration { get; private set; } = 1f;

    private bool Enabled() { return InteractionType == InteractionTypeEnum.Hold; }

    private float _holdTime = 0f;

    public abstract void Interact();

    public abstract string GetDescription();

    public void IncreaseHoldTime() => _holdTime += Time.deltaTime;

    public void DecreaseHoldTime() => _holdTime -= Time.deltaTime;

    public void ResetHoldTime() => _holdTime = 0f;

    public float GetHoldTime() => _holdTime;
}
