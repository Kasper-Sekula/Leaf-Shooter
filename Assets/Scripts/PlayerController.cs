using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] PlayerHealth playerHealth;

    public void CallPlayerMovement()
    {
        playerMovement.CheckInput();
    }

    public PlayerHealth GetPlayerHealthComponent()
    {
        return playerHealth;
    }

    public void DealDamageToPlayer(float amount)
    {
        playerHealth.DealDamage(amount);
    }
}
