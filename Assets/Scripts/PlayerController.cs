using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Canvas playerDiedUI;
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] PlayerHealth playerHealth;
    
    bool isPlayerAlive = true;

    private void Start()
    {
        playerDiedUI.enabled = false;    
    }
    public void CallPlayerMovement()
    {
        playerMovement.CheckInput();
    }

    public PlayerHealth GetPlayerHealthComponent()
    {
        return playerHealth;
    }

    public void HandlePlayerDeath()
    {
        isPlayerAlive = playerHealth.CheckIfPlayerIsAlive();
        if (!isPlayerAlive)
        {
            playerDiedUI.enabled = true;
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
