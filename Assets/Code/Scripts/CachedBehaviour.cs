using UnityEngine;

namespace Code.Scripts
{
    public class CachedBehaviour : MonoBehaviour
    {
        private new Transform transform;

        private void Awake()
        {
            transform = ((Component)this).transform;
        }
    }
}