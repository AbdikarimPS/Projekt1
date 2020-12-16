using UnityEngine;

namespace WeaponScript
{
    [CreateAssetMenu(fileName = "New Gun", menuName = "ScriptableObject", order = 1)]

    public class WeaponData : ScriptableObject
    {
        public new string name;
        public  string description;
        [Range(1,100)] 
        public int minDamage;
        [Range(1,100)] 
        public int maxDamage;
        public int damageValue;
        public  AudioClip sound;
    
    }
}
