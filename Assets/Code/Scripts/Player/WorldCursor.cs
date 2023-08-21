using UnityEngine;

namespace Code.Scripts.Player
{
    public class WorldCursor : CachedBehaviour
    {
        [SerializeField] private Camera _camera;

        public Vector3 Position => transform.position;

        private void Start()
        {
            if (_camera == null)
                _camera = Camera.current;
        }

        private void Update()
        {
            transform.position = _camera.ScreenToWorldPoint(Input.mousePosition);
        }
    }
}