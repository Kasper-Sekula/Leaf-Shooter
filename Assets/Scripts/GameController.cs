using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] PlayerController playerController;
    [SerializeField] WeaponController weaponController;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerController.CallPlayerMovement();
        weaponController.CallWeaponAttack();
    }
}
