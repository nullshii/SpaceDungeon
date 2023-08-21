using UnityEngine;

namespace Code.Scripts.Player
{
    public class PlayerRotation : CachedBehaviour
    {
        [SerializeField] private WorldCursor _worldCursor; 
        
        private void Update()
        {
            transform.up = ((Vector2)_worldCursor.Position - (Vector2)transform.position).normalized;
        }
    }
}