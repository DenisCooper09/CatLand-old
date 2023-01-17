using System.Collections.Generic;
using UnityEngine;

namespace CatLand.Controllers
{
    sealed class GateIndexesController : MonoBehaviour
    {
        [SerializeField] private List<GateController> m_Gates;

        private void Awake()
        {
            RecalculateGateIndexes();
        }

        public void RemoveGate(int index)
        {
            m_Gates.RemoveAt(index);
            RecalculateGateIndexes();
        }

        public void RecalculateGateIndexes()
        {
            for (int i = 0; i < m_Gates.Count; i++)
            {
                m_Gates[i].GateIndex = i;
            }
        }
    }
}
