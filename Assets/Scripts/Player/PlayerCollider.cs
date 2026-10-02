using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    public GameObject battleSystem;
    public GameObject overworld;
    public GameObject gameOverScreen;
    public BattleStats battleSetup;
    public float playerHealth = 50;
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            battleSetup.SetupBattle(other.gameObject);
            overworld.SetActive(false);
            battleSystem.SetActive(true);
        }
    }
}
