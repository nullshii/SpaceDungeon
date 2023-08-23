using UnityEngine;

namespace Code.Scripts
{
    public class WeaponPresenter : MonoBehaviour
    {
        [SerializeField] private Weapon _weapon;

        private void OnEnable()
        {
            _weapon.Shot += OnWeaponShot;
        }

        private void OnDisable()
        {
            _weapon.Shot -= OnWeaponShot;
        }

        private void OnWeaponShot()
        {
            Debug.LogWarning($"{_weapon.AmmoInMagazine} Shot not implemented!");
        }
    }
}