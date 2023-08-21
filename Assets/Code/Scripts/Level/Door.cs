using System;
using UnityEngine;

namespace Code.Scripts.Level
{
    public class Door : MonoBehaviour
    {
        [SerializeField] private BoxCollider2D _collider;
        [SerializeField] private SpriteRenderer _spriteRenderer;
        
        private bool _isEnabled;
        private bool _isInitialized;

        public void Initialize(bool isEnabled)
        {
            if (_isInitialized)
                throw new InvalidOperationException("Door already disabled");

            _isEnabled = isEnabled;
        }
        
        public void Open()
        {
            if (_isEnabled == false) return;

            _collider.enabled = false;
            _spriteRenderer.enabled = false;
        }

        public void Close()
        {
            if (_isEnabled == false) return;
            
            _collider.enabled = true;
            _spriteRenderer.enabled = true;
        }
    }
}