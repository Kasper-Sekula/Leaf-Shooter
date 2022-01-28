using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAttack : MonoBehaviour
{
    [SerializeField] float damage = 20f;
    [SerializeField] Camera FPSCamera;
    [SerializeField] GameObject hitEffect;
    [SerializeField] ParticleSystem muzzleFlash;

    public Transform ProccessRaycastOnMouseButtonDown(int mouseButton)
    {
        if (Input.GetMouseButtonDown(mouseButton))
        {
            RaycastHit raycastHit;
            bool isHit = Physics.Raycast(FPSCamera.transform.position, FPSCamera.transform.forward, out raycastHit);

            PlayMuzzleFlash();
            CreateHitImpact(raycastHit);
            if (isHit)
            {
                return raycastHit.transform;
            }
        }
        return null;
    }

    private void PlayMuzzleFlash()
    {
        muzzleFlash.Play();
    }

    private void CreateHitImpact(RaycastHit ray)
    {
        GameObject impact = Instantiate(hitEffect, ray.point, Quaternion.identity);
        Destroy(impact, 1f);
    }

    public float GetWeaponDamage()
    {
        return damage;
    }
}
