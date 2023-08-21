using System;
using UnityEngine;

namespace Code.Scripts.Level
{
    public class Door : MonoBehaviour
    {
        [SerializeField] private BoxCollider2D _collider;
        [SerializeField] private SpriteRenderer _spriteRenderer;
        
        private bool _isDisabled;

        public void Disable()
        {
            if (_isDisabled)
                throw new InvalidOperationException("Door already disabled");

            _isDisabled = true;
        }
        
        public void Open()
        {
            if (_isDisabled) return;

            _collider.enabled = false;
            _spriteRenderer.enabled = false;
        }

        public void Close()
        {
            if (_isDisabled) return;
            
            _collider.enabled = true;
            _spriteRenderer.enabled = true;
        }
    }
}