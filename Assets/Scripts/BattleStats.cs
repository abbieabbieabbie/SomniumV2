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
    public TMPro.TextMeshProUGUI enemyNameText;
    public GameObject enemyObject;
    public EnemyGeneration enemyPrefabs;
    public GameObject enemyVisual;
    public List<Sprite> visualList;
    public int specialWeapon = 0;
    public int enemyIdentification;
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
                enemyIdentification = 0;
                break;

            case "wolf":
                enemyHealth = 50;
                enemyIdentification = 1;
                break;
            default:
                Debug.Log("NOPE!");
                break;
        }
        enemyVisual.GetComponent<SpriteRenderer>().sprite = visualList[enemyIdentification];
        enemyNameText.text = enemyName;
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
