using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Runtime.CompilerServices;
using UnityEditor.UIElements;

public class PlayerFlashlight : MonoBehaviour
{
    public GameObject flashlight;
    public AudioSource audioSource;

    private bool hasTurnedOn = false;

    public TMP_Text text;

    // Update is called once per frame
    void Update()
    {
        if(!hasTurnedOn && GameManager.instance.hasFlashlight){
            text.text = "left click for flashlight";
        }
        if((Input.GetKeyDown("f") || Input.GetMouseButtonDown(0)) && GameManager.instance.hasFlashlight && GameManager.instance.batteryLevel > 0){
            audioSource.Play();
            flashlight.active = !flashlight.active;

            // ensure that text goes away that explains controls to player
            if(!hasTurnedOn){
                hasTurnedOn = true;
                text.text = "";
            }
        }
        if(Input.GetKeyDown("r") && GameManager.instance.batteryCount > 0){
            GameManager.instance.batteryCount--;
            GameManager.instance.batteryLevel = 100;
        }
    }
}