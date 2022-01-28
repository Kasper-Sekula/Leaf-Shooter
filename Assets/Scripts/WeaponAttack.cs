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
    [SerializeField] AudioSource audioSource;
    bool canFire = true;

    public Transform ProccessRaycastOnMouseButtonDown(int mouseButton)
    {
        if (Input.GetButton("Fire1") && canFire)
        {
            StartCoroutine(CheckIfCanFire());
            RaycastHit raycastHit;
            bool isHit = Physics.Raycast(FPSCamera.transform.position, FPSCamera.transform.forward, out raycastHit);
            print("pressed");
            PlayMuzzleFlash();
            CreateHitImpact(raycastHit);
            PlayAudioClip();
            if (isHit)
            {
                return raycastHit.transform;
            }
        }
        return null;
    }

    IEnumerator CheckIfCanFire()
    {
        canFire = false;
        yield return new WaitForSeconds(0.2f);
        canFire = true;
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

    private void PlayAudioClip()
    {
        audioSource.Play();
    }

    public float GetWeaponDamage()
    {
        return damage;
    }
}
