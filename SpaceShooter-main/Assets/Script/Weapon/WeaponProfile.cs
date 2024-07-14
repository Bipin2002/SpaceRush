using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    [CreateAssetMenu(menuName = "script/weaponProfile")]
    public class WeaponProfile : ScriptableObject
    {
        public float weaponFireRate;
        public float weaponDamage;
        public GameObject bulletObject;
    }
