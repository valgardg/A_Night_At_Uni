using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    float sensX;
    float sensY;

    public Transform orientation;
    public Transform flashlight;
    public Transform enemy;

    float xRotation;
    float yRotation;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        sensX = PlayerPrefs.GetFloat("XSensitivity");
        sensY = PlayerPrefs.GetFloat("YSensitivity");
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.alive)
        {
            // get mouse x input
            float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
            // get mouse x input
            float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

            yRotation += mouseX;
            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            // rotate cam and orientation
            transform.rotation = Quaternion.Euler(xRotation, yRotation, 0f);
            flashlight.rotation = Quaternion.Euler(xRotation, yRotation, 0f);
            orientation.rotation = Quaternion.Euler(0, yRotation, 0);
        }
        else
        {
            Vector3 direction = enemy.position - transform.position;
            Quaternion rotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, 5f * Time.deltaTime);
        }
      
    }

    
    }
