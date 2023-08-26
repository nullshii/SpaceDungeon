using UnityEngine;

namespace Code
{
    public class Boot : MonoBehaviour
    {
        [SerializeField] private Vector2Int _gridSize;
        
        private LevelGenerator _levelGenerator;

        private void Awake()
        {
            _levelGenerator = new LevelGenerator(_gridSize);
        }

        private void Start()
        {
            _levelGenerator.Generate();
        }
    }
}