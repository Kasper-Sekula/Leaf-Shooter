using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField] WeaponAttack weaponAttack;

    public void CallWeaponAttack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Transform shotTarget = weaponAttack.ProccessRaycastOnMouseButtonDown(0);
            if (shotTarget == null) { return; }

            EnemyHealth enemyHealth = shotTarget.GetComponent<EnemyHealth>();
            if (enemyHealth == null) { return; }
            float damage = weaponAttack.GetWeaponDamage();
            enemyHealth.TakeDamage(damage);
            // bool checkIfDied = enemyHealth.Died();
            // if (checkIfDied)
            // {
            //     Destroy(enemyHealth);
            // }
        }
    }
}
