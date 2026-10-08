using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class MenuSelect : MonoBehaviour
{
    private float selected;
    public PlayerCollider player;
    public BattleStats battleStats;
    public List<GameObject> menuList;
    public GameObject shop;
    private int menu = 0;
    public float coins;
    public float coinStash;
    public List<float> prices;
    public TMPro.TextMeshProUGUI costText;
    public TMPro.TextMeshProUGUI coinText;
    public Transform playerTransform;
    // Start is called before the first frame update
    void Start()
    {
        coins = 2000f;
    }

    // Update is called once per frame
    void Update()
    {
        coinText.text = "Coins: " + $"{coins}";
        if (menu == 1)
        {
            UpdatePrice();
        }
        prices[0] = 49 + (float) Math.Pow(prices[1], 4);
        prices[2] = 49 + (float) Math.Pow(prices[3], 4);
        if (Input.GetKeyDown(KeyCode.S))
        {
            selected -= 1;
            if (menu == 1)
            {
                UpdatePrice();
            }
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            selected += 1;
            if (menu == 1)
            {
                UpdatePrice();
            }
        }
        if (menu == 0)
        {
            if (selected < -4)
            {
                selected = 0;
            }
            if (selected > 0)
            {
                selected = -4;
            }
            transform.position = new Vector3(-2.5f,(2.0f + selected), -5f) + transform.parent.position;
        } else if (menu == 1)
        {
            if (selected < -9)
            {
                selected = 0;
                UpdatePrice();
            }
            if (selected > 0)
            {
                selected = -9;
                UpdatePrice();
            }
        }
        
        if (menu == 1)
        {
            switch(selected)
            {
                case 0:
                    transform.position = new Vector3(-1.6f,2.3f,-5f) + transform.parent.position;
                    break;
                case -1:
                    transform.position = new Vector3(-1.9f,1.8f,-5f) + transform.parent.position;
                    break;
                case -2:
                    transform.position = new Vector3(-1.8f,1.25f,-5f) + transform.parent.position;
                    break;
                case -3:
                    transform.position = new Vector3(-1.3f,0.75f,-5f) + transform.parent.position;
                    break;
                case -4:
                    transform.position = new Vector3(-1.3f,0.2f,-5f) + transform.parent.position;
                    break;
                case -5:
                    transform.position = new Vector3(-1.8f,-0.4f,-5f) + transform.parent.position;
                    break;
                case -6:
                    transform.position = new Vector3(-2.1f,-0.9f,-5f) + transform.parent.position;
                    break;
                case -7:
                    transform.position = new Vector3(-1.8f,-1.5f,-5f) + transform.parent.position;
                    break;
                case -8:
                    transform.position = new Vector3(-1.6f,-2.0f,-5f) + transform.parent.position;
                    break;
                case -9:
                    transform.position = new Vector3(-2.6f,-2.5f,-5f) + transform.parent.position;
                    break;
            }
        }
            

        if (Input.GetKeyDown(KeyCode.Space))
        {
            switch(selected)
            {
                case 0:
                    if (menu == 0)
                    {
                        player.overworld.SetActive(true);
                        coinStash = 0;
                        player.playerHealth = player.maxPlayerHealth;
                        transform.parent.gameObject.SetActive(false);
                        playerTransform.position = new Vector3(0,0.6f,-5);
                    }
                    break;
                case -1:
                    if (menu == 0)
                        {
                            for (int i = 0; i < menuList.Count; i++)
                            {
                                menuList[i].SetActive(false);
                            }
                        shop.SetActive(true);
                        selected = 0;
                        menu = 1;
                        UpdatePrice();
                        }
                    if (menu == 1)
                    {
                        if (coins >= prices[4] && battleStats.specialWeapon == 0)
                        {
                            battleStats.specialWeapon = 1;
                        }
                    }
                    break;
                case -4:
                    if (menu == 0)
                    {
                        Application.Quit();
                    }
                    break;
                case -7:
                    if (menu == 1)
                    {
                        if (coins >= prices[0])
                        {
                            coins -= prices[0];
                            player.maxPlayerHealth += 25;
                            prices[1] += 1;
                        }
                    }
                    break;
                case -8:
                    if (menu == 1)
                    {
                        if (coins >= prices[2])
                        {
                            coins -= prices[2];
                            player.damage += 3;
                            prices[3] += 1;
                        }
                    }
                    break;
                case -9:
                    if (menu == 1)
                    {
                        for (int i = 0; i < menuList.Count; i++)
                            {
                                menuList[i].SetActive(true);
                            }
                        shop.SetActive(false);
                        selected = -1;
                        menu = 0;
                    }
                    break;
                default:
                    break;
            }
        }
    }
    public void UpdatePrice()
    {
        switch(selected)
        {
            case 0:
            case -1:
            case -2:
            case -3:
            case -4:
            case -5:
            case -6:
                costText.text = "Cost: " + $"{prices[(int)((Math.Abs(selected) + 4))]}";
                break;
            case -7:
                costText.text = "Cost: " + $"{Math.Floor(prices[0])}";
                break;
            case -8:
                costText.text = "Cost: " + $"{Math.Floor(prices[2])}";
                break;
            case -9:
                costText.text = " ";
                break;
            default:
                break;
        }
    }
    
}
