using UnityEngine;

[RequireComponent(typeof(MovementEngine))]
[RequireComponent(typeof(AnimationEngine))]
public sealed class Cat : CatInput
{
    public bool IsMoving { get; set; } = true;

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
        _movementEngine.MovementInput = IsMoving ? GetMovementInput() : Vector2.zero;
        _animationEngine.PlayAnimation(_movementEngine.MovementInput);
        _animationEngine.RotateToPointer(GetPointerPosition(m_Camera));
    }
}
