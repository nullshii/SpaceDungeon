using System;
using UnityEngine;

namespace Code.Scripts
{
    public class WorldCursor : CachedBehaviour
    {
        [SerializeField] private Camera _camera;

        public Vector3 Position => transform.position;

        private void Start()
        {
            if (_camera == null)
                _camera = Camera.current;

            if (_camera == null)
                throw new NullReferenceException("Can't find camera");
        }

        private void Update()
        {
            transform.position = _camera.ScreenToWorldPoint(Input.mousePosition);
        }
    }
}