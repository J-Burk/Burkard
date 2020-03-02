using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpielerScript : MonoBehaviour
{
    public float speed;
    float winkelY = 0.0f;
    public float InputH;
    public float InputV;
    bool walk1;
    public int Leben;
    public float mousePositionAlt;
    public float mousePositionNeu;

    public float sensitivity = 15.0f;
    public float mouserotation;

    bool keydown;


    void Start()
    {
        speed = 4.0f;
        keydown = false;
    }


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = 7.0f;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = 4.0f;

        }

        InputH = Input.GetAxis("Horizontal");
        InputV = Input.GetAxis("Vertical");

        if (InputV > 0)
        {
            transform.position += transform.forward * speed * Time.deltaTime;
        }
        else if (InputV < 0)
        {
            transform.position -= transform.forward * speed * Time.deltaTime;
        }

        if (InputV != 0)
        {
            walk1 = true;
        }

        if (InputV == 0)
        {
            walk1 = false;
        }

        if (InputH < 0)
        {
            winkelY -= 2.0f;
        }

        if (InputH > 0)
        {
            winkelY += 2.0f;
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, winkelY + mouserotation, 0), Time.deltaTime * 10);


        if (Input.GetMouseButtonDown(1))
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            keydown = true;

        }
        if (Input.GetMouseButtonUp(1))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            keydown = false;
        }

        if (keydown)
        {
            mouserotation += Input.GetAxis("Mouse Y") * sensitivity;
        }


    }
}
