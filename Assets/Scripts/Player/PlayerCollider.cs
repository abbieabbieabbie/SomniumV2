using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    public GameObject battleSystem;
    public GameObject overworld;
    public GameObject gameOverScreen;
    public BattleStats battleSetup;
    public GameObject filter;
    public GameObject pauseMenu;
    public float playerHealth = 50;
    public float maxPlayerHealth = 50;
    public float damage = 5;
    void Update()
    {
        if (gameObject.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                pauseMenu.SetActive(true);
                overworld.SetActive(false);
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            battleSetup.SetupBattle(other.gameObject);
            overworld.SetActive(false);
            filter.SetActive(false);
            battleSystem.SetActive(true);
        }
    }
}
