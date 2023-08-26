using System.Collections.Generic;
using UnityEngine;
using Code.Presenters;

namespace Code
{
    public class LevelGenerator
    {
        private readonly RoomPresenter _roomPresenterSample;

        private readonly Vector2Int _gridSize;
        private readonly bool[,] _visitedRooms;
        private readonly Vector2Int[] _directions;


        public LevelGenerator(Vector2Int gridSize)
        {
            _gridSize = gridSize;
            _visitedRooms = new bool[gridSize.x, gridSize.y];
            _roomPresenterSample = Resources.Load<RoomPresenter>("Prefabs/Room");
            _directions = new[] { Vector2Int.up, Vector2Int.right, Vector2Int.down, Vector2Int.left };
        }

        public void Generate()
        {
            for (var x = 0; x < _gridSize.x; x++)
            {
                for (var y = 0; y < _gridSize.y; y++)
                {
                    if (!_visitedRooms[x, y])
                    {
                        GenerateBranch(x, y);
                    }
                }
            }
        }

        // TODO: Remove duplicated rooms!
        void GenerateBranch(int startX, int startY)
        {
            var stack = new Stack<Vector2Int>();
            stack.Push(new Vector2Int(startX, startY));

            while (stack.Count > 0)
            {
                Vector2Int currentPos = stack.Pop();
                _visitedRooms[currentPos.x, currentPos.y] = true;

                var roomPosition = new Vector3(currentPos.x * Room.Offset, currentPos.y * Room.Offset, 0);
                
                var room = new Room(true, true, true, true);
                RoomPresenter roomPresenter = Object.Instantiate(_roomPresenterSample, roomPosition, Quaternion.identity);
            
                roomPresenter.Init(room);
                room.OpenDoors();
                
                foreach (Vector2Int direction in _directions)
                {
                    Vector2Int neighborPos = currentPos + direction;
                    if (IsPositionValid(neighborPos) && !_visitedRooms[neighborPos.x, neighborPos.y])
                    {
                        stack.Push(neighborPos);
                    }
                }
            }
        }

        bool IsPositionValid(Vector2Int pos)
        {
            return pos.x >= 0 && pos.x < _gridSize.x && pos.y >= 0 && pos.y < _gridSize.y;
        }
    }
}