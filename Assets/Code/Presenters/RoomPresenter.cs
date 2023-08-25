using System;
using UnityEngine;

namespace Code.Presenters
{
    public class RoomPresenter : MonoBehaviour
    {
        [SerializeField] private DoorPresenter _doorUp;
        [SerializeField] private DoorPresenter _doorDown;
        [SerializeField] private DoorPresenter _doorLeft;
        [SerializeField] private DoorPresenter _doorRight;
        
        private Room _room;

        public void Init(Room room)
        {
            if (_room != null)
                throw new InvalidOperationException("Room already initialized.");
                
            _room = room;
            
            _doorUp.Init(room.DoorUp);
            _doorDown.Init(room.DoorDown);
            _doorLeft.Init(room.DoorLeft);
            _doorRight.Init(room.DoorRight);
        }
    }
}