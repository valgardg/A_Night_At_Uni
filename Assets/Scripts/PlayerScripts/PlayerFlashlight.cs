using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFlashlight : MonoBehaviour
{
    public GameObject flashlight;
    public AudioSource audioSource;

    // Update is called once per frame
    void Update()
    {
        if((Input.GetKeyDown("f") || Input.GetMouseButtonDown(0)) && GameManager.instance.hasFlashlight){
            audioSource.Play();
            flashlight.active = !flashlight.active;
        }
    }
}