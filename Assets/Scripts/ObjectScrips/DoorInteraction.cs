﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Runtime.CompilerServices;
using UnityEditor.UIElements;

public class DoorInteraction : MonoBehaviour
{
    public TMP_Text text;
    public KeyCode presskey;
    public int rayDistance;
    public GameObject mydoor;
    public Animation anitmate;
    public AudioSource audioSource;
    bool doorClosed = true;

    void FixedUpdate()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        text.text = "";
        if (Physics.Raycast(ray, out hit, rayDistance))
        {

            if (hit.collider.tag == "Door")
            {
                if(doorClosed && GameManager.instance.hasKey){
                    //GameManager.instance.UpdateTextPrompt(hit.collider.tag, "press E to open " + hit.collider.tag);
                    text.text = "press E to open " + hit.collider.tag;
                }

                if(doorClosed && !GameManager.instance.hasKey){
                    //GameManager.instance.UpdateTextPrompt(hit.collider.tag, "door requires keys");
                    text.text = "door requires keys ";
                }

                if (Input.GetKeyDown(presskey) && doorClosed && GameManager.instance.hasKey)
                {
                    text.text = "press E to open " + hit.collider.tag;
                    anitmate.Play();
                    audioSource.Play();
                    doorClosed = false;
                    text.text = "";
                }
            }
        }
    }
}
