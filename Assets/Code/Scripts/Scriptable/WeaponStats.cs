using UnityEngine;

namespace Code.Scripts.Scriptable
{
    [CreateAssetMenu(fileName = "WeaponStats", menuName = "Game/WeaponStats", order = 0)]
    public class WeaponStats : ScriptableObject
    {
        public float ShootCooldown;
        public float ReloadCooldown;

        public int MagazineCapacity;
        public int Damage;
    }
}