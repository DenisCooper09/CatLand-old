using UnityEngine;
using UnityEngine.Events;
using NaughtyAttributes;

namespace CatLand.Systems.FundamentalSystems.InteractionSystem
{
    abstract class Interactable : Selectable
    {
        public enum InteractionTypeEnum { Click, Hold }

        [field: SerializeField]
        public InteractionTypeEnum InteractionType { get; set; }

        private bool IsEnabled() => InteractionType == InteractionTypeEnum.Hold;

        [field: SerializeField, ShowIf(nameof(IsEnabled))]
        public float InteractionDuration { get; set; } = 1f;

        [SerializeField] private UnityEvent OnInteract;

        private float _holdTime = 0f;

        public virtual void Interact() => OnInteract?.Invoke();

        public void IncreaseHoldTime() => _holdTime += Time.deltaTime;

        public void DecreaseHoldTime() => _holdTime -= Time.deltaTime;

        public void ResetHoldTime() => _holdTime = 0f;

        public float GetHoldTime() => _holdTime;
    }
}
