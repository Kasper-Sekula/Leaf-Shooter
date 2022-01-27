using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAttack : MonoBehaviour
{
    [SerializeField] Camera FPSCamera;
    public void ProccessRaycastOnMouseButtonDown(int mouseButton)
    {
        if (Input.GetMouseButtonDown(mouseButton))
        {
            RaycastHit raycastHit;
            bool isHit = Physics.Raycast(FPSCamera.transform.position, FPSCamera.transform.forward, out raycastHit);

            if (isHit)
            {
                print(raycastHit.transform.name);
            }
            else
            {
                return;
            }
        }

    }
}
