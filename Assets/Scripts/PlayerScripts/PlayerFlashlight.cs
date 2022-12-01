using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFlashlight : MonoBehaviour
{
    public GameObject flashlight;
    public AudioSource audioSource;

    bool flashlightActive = true;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("f")){
            audioSource.Play();
            flashlight.active = !flashlightActive;
            flashlightActive = !flashlightActive;
        }
    }
}