using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSelect : MonoBehaviour
{
    private int selected;
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
        transform.position = new Vector3(-2.2f,(2 + selected), 0f);
    }
    
}
