using System;
using System.Collections.Generic;
using UnityEngine;

namespace Code.Scripts.Level
{
    public class LevelGenerator : MonoBehaviour
    {
        [SerializeField] private Room _room;

        private List<Room> _rooms;

        public event Action Done;

        private void Start()
        {
            _rooms = new List<Room>();
            Generate();
        }

        private void Generate()
        {
            Room instance = Instantiate(_room, Vector3.zero, Quaternion.identity);
            _rooms.Add(instance);
            
            Done?.Invoke();
            
            throw new NotImplementedException("Still implementing...");
        }

        private void OpenAllDoors()
        {
            foreach (Room room in _rooms)
            {
                room.OpenDoors();
            }
        }

        private void CloseAllDoors()
        {
            foreach (Room room in _rooms)
            {
                room.CloseDoors();
            }
        }
    }
}