using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;

    bool isDead = false;

    public void TakeDamage(float damage)
    {
        hitPoints -= damage;
        if (hitPoints <= 0)
        {
            //isDead = true;
            Died();
        }
    }

    private void Died()
    {
        isDead = true;
        Destroy(gameObject);
        //return isDead ? true : false;
    }
}
