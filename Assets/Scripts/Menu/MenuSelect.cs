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
    private float coins = 0f;
    public List<float> prices;
    public TMPro.TextMeshProUGUI costText;
    public GameObject shopBox;
    public Transform playerTransform;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
            transform.position = new Vector3(-3.0f,(2.0f + selected), -5f) + transform.parent.position;
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
            }
            transform.position = new Vector3(-2.0f,(2.5f + (selected / 1.95f)), -5f) + transform.parent.position;
        }
        

        if (Input.GetKeyDown(KeyCode.Space))
        {
            switch(selected)
            {
                case 0:
                    if (menu == 0)
                    {
                        player.overworld.SetActive(true);
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
                        shopBox.SetActive(true);
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
                        shopBox.SetActive(false);
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
            case -9:
                costText.text = " ";
                break;
            default:
                break;
        }
    }
    
}
