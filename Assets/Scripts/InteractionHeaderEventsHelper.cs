using UnityEngine;
using UnityEngine.Events;

namespace CatLand
{
    sealed class InteractionHeaderEventsHelper : MonoBehaviour
    {
        [SerializeField] private UnityEvent OnAnimationEnded;

        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void OnAnimationEndedMethod()
        {
            OnAnimationEnded?.Invoke();
            _animator.SetTrigger("TextIn");
        }
    }
}
