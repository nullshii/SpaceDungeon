using Code.Events;

namespace Code
{
    public interface IDoor
    {
        public event DoorEvent Opened;
        public event DoorEvent Closed;

        public bool IsEnabled { get; }

        public void Open();
        public void Close();
    }
}