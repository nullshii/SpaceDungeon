using System;
using Code.Scripts.Global;
using Code.Scripts.Scriptable;
using UnityEngine;
using Zenject;

namespace Code.Scripts
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField] private WeaponStats _stats;

        [Inject] private GameplaySettings _gameplaySettings;
        private Cooldown _reloadCooldown;

        private Cooldown _shootCooldown;

        public int AmmoInMagazine { get; private set; }

        private void Awake()
        {
            AmmoInMagazine = _stats.MagazineCapacity;

            _shootCooldown = new Cooldown(_stats.ShootCooldown);
            _reloadCooldown = new Cooldown(_stats.ReloadCooldown);
        }

        private void Update()
        {
            _shootCooldown.Update(Time.deltaTime);
            _reloadCooldown.Update(Time.deltaTime);
        }

        private void OnEnable()
        {
            _reloadCooldown.Done += ReloadCooldownDone;
        }

        private void OnDisable()
        {
            _reloadCooldown.Done -= ReloadCooldownDone;
        }

        public event Action Shot;

        public void Shoot()
        {
            if (_shootCooldown.Available == false) return;
            if (_reloadCooldown.Available == false) return;

            if (AmmoInMagazine <= 0)
            {
                if (_gameplaySettings.AutoReload)
                    Reload();

                return;
            }

            _shootCooldown.Use();
            AmmoInMagazine--;
            Shot?.Invoke();
        }

        public void Reload()
        {
            if (!_reloadCooldown.Available) return;
            _reloadCooldown.Use();
        }

        private void ReloadCooldownDone()
        {
            AmmoInMagazine = _stats.MagazineCapacity;
        }
    }
}