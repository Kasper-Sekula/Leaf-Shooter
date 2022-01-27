using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] PlayerMovement playerMovement;
    void Start()
    {
        
    }

    void Update()
    {
        playerMovement.CheckInput();
    }
}
