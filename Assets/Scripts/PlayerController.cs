using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Canvas playerDiedUI;
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] PlayerHealth playerHealth;
    [SerializeField] PlayerHealth treeHealth;
    
    bool isPlayerAlive = true;
    bool isTreeAlive = true;

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
        isTreeAlive = treeHealth.CheckIfPlayerIsAlive();
        if (!isPlayerAlive || !isTreeAlive)
        {
            playerDiedUI.enabled = true;
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
