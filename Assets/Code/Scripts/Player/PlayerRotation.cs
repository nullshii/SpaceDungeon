using System;
using UnityEngine;

namespace Code.Scripts.Player
{
    public class PlayerRotation : CachedBehaviour
    {
        [SerializeField] private WorldCursor _worldCursor;

        private void Start()
        {
            if (_worldCursor == null)
                _worldCursor = FindFirstObjectByType<WorldCursor>();

            if (_worldCursor == null)
                throw new NullReferenceException("Can't find world cursor");
        }

        private void Update()
        {
            transform.up = ((Vector2)_worldCursor.Position - (Vector2)transform.position).normalized;
        }
    }
}