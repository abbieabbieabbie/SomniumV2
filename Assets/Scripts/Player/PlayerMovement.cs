using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 2;
    
    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 3.5f;
        } else
        {
            speed = 2;
        }

        Vector3 movement = new Vector3(x, 0, z);
        transform.Translate(movement * speed * Time.deltaTime);
    }
}
