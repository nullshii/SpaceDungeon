using System;
using System.Collections.Generic;
using UnityEngine;
using Code.Presenters;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

namespace Code
{
    public class LevelGenerator
    {
        private readonly List<Vector2> _roomGrid;
        private readonly RoomPresenter _roomPresenterSample;

        public LevelGenerator()
        {
            _roomGrid = new List<Vector2>();
            _roomPresenterSample = Resources.Load<RoomPresenter>("Prefabs/Room");
        }

        public void Generate(int roomCount)
        {
            var checkedRooms = new List<Vector2>();
            
            _roomGrid.Add(Vector2.zero);

            while (_roomGrid.Count < roomCount)
            {
                Vector2 direction = Random.Range(0, 4) switch
                {
                    0 => Vector2.up,
                    1 => Vector2.down,
                    2 => Vector2.left,
                    3 => Vector2.right,
                    _ => throw new ArgumentOutOfRangeException()
                };

                Vector2 randomRoom = _roomGrid[Random.Range(0, _roomGrid.Count)];
                
                if (checkedRooms.Contains(randomRoom)) continue;
                
                checkedRooms.Add(randomRoom);
                _roomGrid.Add(randomRoom + direction * Room.Offset);
            }

            foreach (Vector2 vector2 in _roomGrid)
            {
                var room = new Room(true, false, false, false);
                RoomPresenter roomPresenter = Object.Instantiate(_roomPresenterSample);

                roomPresenter.transform.position = vector2;
                
                roomPresenter.Init(room);
                room.OpenDoors();
            }
        }
    }
}