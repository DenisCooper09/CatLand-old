using System;
using UnityEngine;
using UnityEngine.Events;

namespace CatLand
{
    sealed class FadeImageEvents : MonoBehaviour
    {
        [SerializeField] private UnityEvent OnFadeStarted;
        [SerializeField] private UnityEvent OnFadeCompleteUnityEvent;
        public static event Action OnLoadingStarted;
        public static event Action OnFadeComplete;

        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void OnLoadingStartedMethod()
        {
            OnLoadingStarted?.Invoke();
        }

        public void OnFadeStartedMethod()
        {
            OnFadeStarted?.Invoke();
        }

        public void OnFadeInStarted()
        {
            _animator.SetTrigger("OnFadeIn");
        }

        public void OnFadeCompleteMethod()
        {
            OnFadeComplete?.Invoke();
            OnFadeCompleteUnityEvent?.Invoke();
        }
    }
}
