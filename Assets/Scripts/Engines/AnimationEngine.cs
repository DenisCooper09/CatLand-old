using UnityEngine;
using NaughtyAttributes;

[RequireComponent(typeof(Animator))]
public sealed class AnimationEngine : MonoBehaviour
{
    [SerializeField] private Animator m_Animator = null;
    [SerializeField, AnimatorParam(nameof(m_Animator))] private string m_ParameterName;

    public void PlayAnimation(Vector2 movementInput)
    {
        m_Animator.SetBool(m_ParameterName, movementInput.magnitude > 0f);
    }

    public void RotateToPointer(Vector2 pointerPosition)
    {
        Vector2 scale = transform.localScale;
        scale.x = pointerPosition.x > transform.position.x ? 1f : -1f;
        transform.localScale = scale;
    }
}
