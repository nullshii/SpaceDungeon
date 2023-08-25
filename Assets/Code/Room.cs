namespace Code
{
    public class Room
    {
        public static int Offset = 30;
        
        private readonly Door _doorUp;
        private readonly Door _doorDown;
        private readonly Door _doorLeft;
        private readonly Door _doorRight;

        public Room(bool enableUp, bool enableDown, bool enableLeft, bool enableRight)
        {
            _doorUp = new Door(enableUp);
            _doorDown = new Door(enableDown);
            _doorLeft = new Door(enableLeft);
            _doorRight = new Door(enableRight);
        }

        public IDoor DoorUp => _doorUp;
        public IDoor DoorDown => _doorDown;
        public IDoor DoorLeft => _doorLeft;
        public IDoor DoorRight => _doorRight;

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