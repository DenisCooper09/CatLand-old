using UnityEngine;

[RequireComponent(typeof(MovementEngine))]
[RequireComponent(typeof(AnimationEngine))]
public sealed class Cat : CatInput
{
    [SerializeField] private Camera m_Camera;

    private MovementEngine _movementEngine;
    private AnimationEngine _animationEngine;

    protected override void Awake()
    {
        base.Awake();

        _movementEngine = GetComponent<MovementEngine>();
        _animationEngine = GetComponent<AnimationEngine>();
    }

    private void Update()
    {
        _movementEngine.MovementInput = GetMovementInput();
        _animationEngine.PlayAnimation(_movementEngine.MovementInput);
        _animationEngine.RotateToPointer(GetPointerPosition(m_Camera));
    }
}
