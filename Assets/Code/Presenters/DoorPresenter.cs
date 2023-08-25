using System;
using UnityEngine;

namespace Code.Presenters
{
    public class DoorPresenter : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private Collider2D _collider;

        public IDoor Door { get; private set; }

        public void Init(IDoor door)
        {
            if (Door != null)
                throw new InvalidOperationException("Room already initialized.");
                
            Door = door;
            
            Door.Opened += OnDoorOpen;
            Door.Closed += OnDoorClose;
        }

        private void OnDestroy()
        {
            Door.Opened -= OnDoorOpen;
            Door.Closed -= OnDoorClose;
        }

        private void OnDoorOpen()
        {
            _spriteRenderer.enabled = false;
            _collider.enabled = false;
        }

        private void OnDoorClose()
        {
            _spriteRenderer.enabled = true;
            _collider.enabled = true;
        }
    }
}