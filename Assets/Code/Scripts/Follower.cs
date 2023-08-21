using UnityEngine;

namespace Code.Scripts
{
    public class Follower : CachedBehaviour
    {
        [SerializeField] private Transform _target;
        [SerializeField] private Vector3 _offset;
        [SerializeField] private float _speed;

        private void Update()
        {
            transform.position = Vector3.Lerp(transform.position, _target.position + _offset, _speed * Time.deltaTime);
        }
    }
}