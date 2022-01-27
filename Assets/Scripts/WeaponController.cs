using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField] WeaponAttack weaponAttack;

    public void CallWeaponAttack()
    {
        weaponAttack.ProccessRaycast();
    }
}
