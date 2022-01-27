using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAttack : MonoBehaviour
{
    [SerializeField] Camera FPSCamera;
    [SerializeField] float damage = 20f;
    public Transform ProccessRaycastOnMouseButtonDown(int mouseButton)
    {
        if (Input.GetMouseButtonDown(mouseButton))
        {
            RaycastHit raycastHit;
            bool isHit = Physics.Raycast(FPSCamera.transform.position, FPSCamera.transform.forward, out raycastHit);

            if (isHit)
            {
                return raycastHit.transform;
            }
        }
        return null;
    }

    public float GetWeaponDamage()
    {
        return damage;
    }
}
