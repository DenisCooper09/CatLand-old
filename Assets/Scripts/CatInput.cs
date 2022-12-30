using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using NaughtyAttributes;

public sealed class CatInput : MonoBehaviour
{
    [SerializeField] private Camera m_Camera;

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
        OnPointerInput?.Invoke((Vector2)m_Camera.ScreenToWorldPoint(_catInputActions.Cat.PointerPosition.ReadValue<Vector2>()));
    }
}
