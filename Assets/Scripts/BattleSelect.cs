using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BattleSelect : MonoBehaviour
{
    public int previousMenu;
    public int battleMenu = 0;
    public int HorSelect = 0;
    public int VerSelect = 0;
    public List<GameObject> disableList;
    public List<GameObject> battleList;
    public BattleAttack attackScript;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!attackScript.inDialog)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                SelectPosition(-1, 0); // Left
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                SelectPosition(1, 0); // Right
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                SelectPosition(0, -1); // Up
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                SelectPosition(0, 1); // Down
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                BattleSelection((HorSelect + 1) + (VerSelect * 2));
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (battleMenu != 0)
                {
                    EscapeToSelect(0);
                }
            }
        }
    }

        void MoveToPosition(float x, float y)
    {
        transform.position = new Vector3(x,y,transform.position.z);
    }

    public void SelectPosition(int hor, int ver) // Determines where the arrow will be 
    {
        HorSelect += hor;
        VerSelect += ver;
       // Avoid negative numbers
        HorSelect = Math.Abs(HorSelect);
        VerSelect = Math.Abs(VerSelect);

        if (HorSelect > 1)
            {
                HorSelect = 0;
            } 
        if (VerSelect > 1)
            {
                VerSelect = 0;
            }

        if (battleMenu == 0) { // If you are not selecting anything
            if (HorSelect == 0 && VerSelect == 0)
            {
                MoveToPosition(-7.8f,3.1f);
            } else if (HorSelect == 1 && VerSelect == 0)
            {
                MoveToPosition(-4.7f,3.1f);
            } else if (HorSelect == 0 && VerSelect == 1)
            {
                MoveToPosition(-7.8f,2.3f);
            } else if (HorSelect == 1 && VerSelect == 1)
            {
                MoveToPosition(-4.7f,2.3f);
            }
        }
    }
    public void BattleSelection(int menu)
    {
        previousMenu = battleMenu;
        battleMenu = menu;
        if (battleMenu == 1)
        {
            if (previousMenu == 1)
            {
                attackScript.Attack(1, 5);
            } else
            {
                for (int i = 0; i < disableList.Count; i++)
                {
                    disableList[i].SetActive(false);
                }
                for (int i = 0; i < battleList.Count; i++)
                {
                    battleList[i].SetActive(true);
                }
            }
            
        }
    }

    public void EscapeToSelect(int menuOverride)
    {
        attackScript.inDialog = false;
        if (menuOverride > 0)
        {
            switch(menuOverride)
            {
                case 1:
                    MoveToPosition(-7.8f,3.1f);
                    break;
                case 2:
                    MoveToPosition(-4.7f,3.1f);
                    break;
                case 3:
                    MoveToPosition(-7.8f,2.3f);
                    break;
                default:
                    MoveToPosition(-4.7f,2.3f);
                    break;
            }
        } else
        {
            switch(battleMenu)
            {
                case 1:
                    MoveToPosition(-7.8f,3.1f);
                    break;
                case 2:
                    MoveToPosition(-4.7f,3.1f);
                    break;
                case 3:
                    MoveToPosition(-7.8f,2.3f);
                    break;
                default:
                    MoveToPosition(-4.7f,2.3f);
                    break;
            }
        }
        battleMenu = 0;
        for (int i = 0; i < disableList.Count; i++)
            {
                disableList[i].SetActive(true);
            }
            for (int i = 0; i < battleList.Count; i++)
            {
                battleList[i].SetActive(false);
            }
    }
}
