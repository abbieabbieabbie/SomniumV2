using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BattleStats : MonoBehaviour
{
    public string enemyName;
    public float enemyHealth;
    public PlayerCollider player;
    public PlayerMovement playerPos;
    public TMPro.TextMeshProUGUI healthText;
    public GameObject enemyObject;
    public EnemyGeneration enemyPrefabs;
    public int specialWeapon = 0;
    // Start is called before the first frame update
    public void SetupBattle(GameObject enemy)
    {
        enemyName = enemy.name;
        enemyObject = enemy;
        UpdateHealth();
        
        switch(enemyName)
        {
            case "spider":
                enemyHealth = 40;
                break;

            default:
                Debug.Log("NOPE!");
                break;
        }
    }
    public void UpdateHealth()
    {
        healthText.text = $"{Math.Ceiling(player.playerHealth)}";
    }

    public void WinCondition()
    {
        if (enemyHealth <= 0)
        {
            Destroy(enemyObject);
            player.overworld.SetActive(true);
            player.battleSystem.SetActive(false);
        }
        if (player.playerHealth <= 0)
        {
            Destroy(enemyObject);
            player.battleSystem.SetActive(false);
            player.gameOverScreen.SetActive(true);
            enemyPrefabs.GameOver();
        }
    }
}
