using System;
using UnityEngine;
using UnityEngine.Events;

namespace CatLand.Systems.ConsoleSystem.Commands
{
    [Serializable]
    class Command
    {
        public event Action OnCommandCallCSharpEvent;
        public event Action<int> OnCommandCallCSharpEventIndex;

        public void CallCSharpEvent() => OnCommandCallCSharpEvent?.Invoke();

        public void CallCSharpEventIndex(int index) => OnCommandCallCSharpEventIndex?.Invoke(index);

        [field: SerializeField]
        public UnityEvent OnCommandCall { get; private set; }

        [field: SerializeField]
        public UnityEvent<int> OnCommandCallIndex { get; private set; }

        [field: SerializeField]
        public string CommandSyntax { get; private set; }

        [field: SerializeField]
        public bool RemoveAfterCall { get; private set; }

        [field: SerializeField]
        public bool IsBlocked { get; set; }

        [field: SerializeField]
        public string MessageIfBlocked { get; private set; }
    }
}
