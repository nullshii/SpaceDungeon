using UnityEngine;

namespace Code
{
    public class Boot : MonoBehaviour
    {
        [SerializeField] private int _roomCount;
        
        private LevelGenerator _levelGenerator;

        private void Awake()
        {
            _levelGenerator = new LevelGenerator();
        }

        private void Start()
        {
            _levelGenerator.Generate(_roomCount);
        }
    }
}