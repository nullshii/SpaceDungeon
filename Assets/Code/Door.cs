using Code.Events;

namespace Code
{
    public class Door : IDoor
    {
        public event DoorEvent Opened;
        public event DoorEvent Closed;

        public bool IsEnabled { get; }

        public Door(bool enabled)
        {
            IsEnabled = enabled;
        }

        public void Open()
        {
            if (IsEnabled == false)
                Opened?.Invoke();
        }

        public void Close()
        {
            if (IsEnabled == false)
                Closed?.Invoke();
        }
    }
}