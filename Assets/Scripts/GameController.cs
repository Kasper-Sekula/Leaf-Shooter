using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    // CONTROLLERS
    [SerializeField] EnemyController enemyController;
    [SerializeField] PlayerController playerController;
    [SerializeField] WeaponController weaponController;

    SceneLoader sceneLoader;
    void Start()
    {
        sceneLoader = GetComponent<SceneLoader>();
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        //enemyController.DealDamageToPlayer();
        playerController.CallPlayerMovement();
        playerController.HandlePlayerDeath();

        enemyController.SpawningEnemies();
        enemyController.GetEnemyAI();

        weaponController.CallWeaponAttack();
    }

    public void PlayAgain(int sceneNumber)
    {
        sceneLoader.ReloadGame(sceneNumber);
    }

    public void QuitPlaying()
    {
        sceneLoader.QuitPlaying();
    }
    
}
