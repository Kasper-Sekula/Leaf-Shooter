using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float health = 100f;

    public void DealDamage(float amount)
    {
        health -= amount;
        if (health <0)
        {
            print("Player died");
        }
    }
}