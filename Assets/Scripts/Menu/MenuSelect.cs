using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSelect : MonoBehaviour
{
    private float selected;
    public PlayerCollider player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            selected -= 1;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            selected += 1;
        }
        if (selected < -4)
        {
            selected = 0;
        }
        if (selected > 0)
        {
            selected = -4;
        }
        transform.position = new Vector3(-3.0f,(2.0f + selected), -5f) + transform.parent.position;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            switch(selected)
            {
                case 0:
                    player.overworld.SetActive(true);
                    transform.parent.gameObject.SetActive(false);
                    break;
                case -4:
                    Application.Quit();
                    break;
                default:
                    break;
            }
        }
    }
    
}
