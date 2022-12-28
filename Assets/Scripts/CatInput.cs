using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class CatInput : MonoBehaviour
{
    public static event Action OnDropButtonPressed;

    private CatInputActions _catInputActions;

    protected virtual void Awake()
    {
        _catInputActions = new CatInputActions();
        _catInputActions.Cat.Enable();
        _catInputActions.Cat.Drop.performed += PerformDrop;
    }

    private void PerformDrop(InputAction.CallbackContext context)
    {
        if (context.performed)
            OnDropButtonPressed?.Invoke();
    }

    protected Vector2 GetMovementInput()
    {
        return _catInputActions.Cat.Movement.ReadValue<Vector2>();
    }

    protected Vector2 GetPointerPosition(Camera camera)
    {
        return (Vector2)camera.ScreenToWorldPoint(_catInputActions.Cat.PointerPosition.ReadValue<Vector2>());
    }
}
