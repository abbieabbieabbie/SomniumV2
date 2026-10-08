using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseSelect : MonoBehaviour
{
    [SerializeField]
    private int select = 0;
    public GameObject pauseMenu;
    public PlayerCollider player;
    public MenuSelect shop;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.activeSelf)
        {
            switch(select)
            {
                case 0:
                    transform.position = new Vector3(997.5f, 1.35f, 7f);
                    break;
                case -1:
                    transform.position = new Vector3(998.5f, -1.15f, 7f);
                    break;
            }

            if (Input.GetKeyDown(KeyCode.W))
            {
                select += 1;
                if (select > 0)
                {
                    select = -1;
                }
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                select -= 1;
                if (select < -1)
                {
                    select = 0;
                }
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (select == 0)
                {
                    player.overworld.SetActive(true);
                    pauseMenu.SetActive(false);
                }
                if (select == -1)
                {
                    player.gameOverScreen.SetActive(true);
                    shop.coins += shop.coinStash;
                    pauseMenu.SetActive(false);
                }
            }
        }
    }
}
