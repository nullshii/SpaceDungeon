using System;
using UnityEngine;

namespace Code.Scripts.Level
{
    public class Room : MonoBehaviour
    {
        [SerializeField] private Door _doorUp;
        [SerializeField] private Door _doorDown;
        [SerializeField] private Door _doorLeft;
        [SerializeField] private Door _doorRight;

        private bool _isInitialized;

        public void Initialize(bool enableUpDoor = true, bool enableDownDoor = true,
            bool enableLeftDoor = true, bool enableRightDoor = true)
        {
            if (_isInitialized)
                throw new InvalidOperationException("Room already initialized");

            _doorUp.Initialize(enableUpDoor);
            _doorDown.Initialize(enableDownDoor);
            _doorLeft.Initialize(enableLeftDoor);
            _doorRight.Initialize(enableRightDoor);

            _isInitialized = true;
        }

        public void OpenDoors()
        {
            _doorUp.Open();
            _doorDown.Open();
            _doorLeft.Open();
            _doorRight.Open();
        }

        public void CloseDoors()
        {
            _doorUp.Close();
            _doorDown.Close();
            _doorLeft.Close();
            _doorRight.Close();
        }
    }
}