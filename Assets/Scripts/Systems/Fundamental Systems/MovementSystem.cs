using UnityEngine;

namespace CatLand.Systems.FundamentalSystems
{
    [RequireComponent(typeof(Rigidbody2D))]
    sealed class MovementSystem : MonoBehaviour
    {
        public Vector2 MovementInput { get; set; }

        [SerializeField, Min(0)]
        private float m_MaxSpeed = 4.5f, m_Acceleration = 3f, m_Deacceleration = 4f;

        private float _currentSpeed;
        private Vector2 _oldMovementInput;
        private Rigidbody2D _rigidbody2d;

        private void Awake()
        {
            _rigidbody2d = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            if (MovementInput.magnitude > 0f && _currentSpeed >= 0f)
            {
                _oldMovementInput = MovementInput;
                _currentSpeed += m_Acceleration * m_MaxSpeed * Time.deltaTime;
            }
            else _currentSpeed -= m_Deacceleration * m_MaxSpeed * Time.deltaTime;

            _currentSpeed = Mathf.Clamp(_currentSpeed, 0f, m_MaxSpeed);
            _rigidbody2d.velocity = _oldMovementInput * _currentSpeed;
        }
    }
}
