using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerCamera : MonoBehaviour
{
    public Vector2 turn;
    public GameObject player;
    private Vector3 deltaMove;
    private float sensitivity = 2f;
    private float speed = 3;
    private Vector3 pitchMinMax = new Vector3(-90,90,0);

    private float pitch;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 1.4f, player.transform.position.z);
    }
    void Update()
    {
        turn.x += Input.GetAxis("Mouse X") * sensitivity;
        pitch -= Input.GetAxis("Mouse Y") * sensitivity;

        pitch = Mathf.Clamp(pitch, pitchMinMax.x, pitchMinMax.y);
        player.transform.localRotation = Quaternion.Euler(0,turn.x,0);
        transform.localRotation = Quaternion.Euler(pitch, 0, 0);

        deltaMove = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")) * speed * Time.deltaTime;
        player.transform.Translate(deltaMove);
    }
}
