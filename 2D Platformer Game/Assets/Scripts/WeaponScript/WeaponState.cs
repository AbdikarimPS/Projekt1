using UnityEngine;

namespace WeaponScript
{
    public class WeaponState : MonoBehaviour
    {

        public WeaponData WeaponData;
        public AudioSource source;
        private void Update()
        {
            if (!Input.GetKeyDown(KeyCode.Space)) return;
            WeaponData.damageValue =  Random.Range(WeaponData.minDamage, WeaponData.maxDamage);
            Debug.Log($"Weapon: {WeaponData.name} Description:  {WeaponData.description}  minDamage: {WeaponData.damageValue}");
            source.clip = WeaponData.sound;
            source.Play();
        }
    }
}


