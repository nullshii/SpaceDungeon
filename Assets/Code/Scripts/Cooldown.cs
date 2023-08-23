using System;

namespace Code.Scripts
{
    public class Cooldown
    {
        private readonly float _maxCooldown;
        private float _cooldown;

        public Cooldown(float maxCooldown)
        {
            _maxCooldown = maxCooldown;
        }

        public bool Available { get; private set; }

        public event Action Done;

        public void Update(float delta)
        {
            if (Available) return;

            _cooldown -= delta;

            if (_cooldown <= 0f)
            {
                Available = true;
                Done?.Invoke();
            }
        }

        public void Use()
        {
            _cooldown = _maxCooldown;
            Available = false;
        }
    }
}