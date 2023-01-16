using System;
using UnityEngine;
using NaughtyAttributes;

namespace CatLand.Systems.ConsoleSystem.Commands
{
    [Serializable]
    sealed class ProtectedCommand : Command
    {
        [field: SerializeField]
        public BinaryMathematicalOperationType OperationType { get; private set; }

        [field: SerializeField, MinMaxSlider(0, 100)]
        public Vector2Int MinMaxNumber { get; private set; }
    }
}
