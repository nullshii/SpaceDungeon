using UnityEngine;

namespace Code.Scripts.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float _speed;

        private Vector2 _direction;
        private Rigidbody2D _rigidbody;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            _direction = Input.GetAxis("Horizontal") * Vector2.right 
                         + Input.GetAxis("Vertical") * Vector2.up;
        }

        private void FixedUpdate()
        {
            _rigidbody.velocity = _direction * (_speed * Time.deltaTime);
        }
    }
}