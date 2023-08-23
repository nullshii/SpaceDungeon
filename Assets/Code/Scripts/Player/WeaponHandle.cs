using UnityEngine;

namespace Code.Scripts.Player
{
    public class WeaponHandle : MonoBehaviour
    {
        [SerializeField] private Weapon _weapon;

        private void Update()
        {
            if (Input.GetButton("Fire1")) _weapon.Shoot();

            if (Input.GetButton("Reload")) _weapon.Reload();
        }
    }
}