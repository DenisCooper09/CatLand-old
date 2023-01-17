using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using NaughtyAttributes;

namespace CatLand
{
    sealed class CatInput : MonoBehaviour
    {
        [field: SerializeField]
        public Camera Camera { get; set; }

        private const string UnityEvents = "Unity Events";

        [SerializeField, Foldout(UnityEvents)] private UnityEvent<Vector2> OnMovementInput, OnPointerInput;
        [SerializeField, Foldout(UnityEvents)] private UnityEvent OnDrop;

        private CatInputActions _catInputActions;

        private void Awake()
        {
            _catInputActions = new CatInputActions();
            _catInputActions.Cat.Enable();
            _catInputActions.Cat.Drop.performed += PerformDrop;
        }

        private void PerformDrop(InputAction.CallbackContext context)
        {
            if (context.performed)
                OnDrop?.Invoke();
        }

        private void Update()
        {
            OnMovementInput?.Invoke(_catInputActions.Cat.Movement.ReadValue<Vector2>());
            OnPointerInput?.Invoke(GetPointerInput());
        }

        private Vector2 GetPointerInput()
        {
            return (Vector2)Camera.ScreenToWorldPoint(_catInputActions.Cat.PointerPosition.ReadValue<Vector2>());
        }
    }
}
