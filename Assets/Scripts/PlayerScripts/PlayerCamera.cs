using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    float sensX;
    float sensY;

    public Transform orientation;
    public Transform flashlight;

    float xRotation;
    float yRotation;
    private int inverted;

    // Start is called before the first frame update
    private void Awake()
    {
        inverted = PlayerPrefs.GetInt("Inverted");
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        sensX = PlayerPrefs.GetFloat("XSensitivity");
        sensY = PlayerPrefs.GetFloat("YSensitivity");
        AudioListener.volume = PlayerPrefs.GetFloat("MusicVolume");
        Debug.Log(AudioListener.volume);
    }

    // Update is called once per frame
    void Update()
    {
       
        // get mouse x input
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX * inverted;
        // get mouse x input
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY * inverted;

        yRotation += mouseX;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // rotate cam and orientation
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0f);
        flashlight.rotation = Quaternion.Euler(xRotation, yRotation, 0f);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);

    }
}
