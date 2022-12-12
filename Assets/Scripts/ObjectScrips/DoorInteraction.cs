using System.Collections;
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
    public Animation animate;
    public AudioSource audioSource;
    bool doorClosed = true;

    private void Start()
    {
        mydoor = gameObject;
    }
    void FixedUpdate()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        text.text = "";
        if (Physics.Raycast(ray, out hit, rayDistance))
        {

            if (hit.collider.tag == "Door")
            {

                Debug.Log(hit.collider.gameObject);
                if (doorClosed && GameManager.instance.hasStartRoomKey){
                    text.text = "press E to open " + hit.collider.tag;
                }

                if(doorClosed && !GameManager.instance.hasStartRoomKey){
                    text.text = "door requires key";
                }

                if (Input.GetKeyDown(presskey) && doorClosed && GameManager.instance.hasStartRoomKey)
                {
                    text.text = "press E to open " + hit.collider.tag;
                    animate.Play();
                    audioSource.Play();
                    doorClosed = false;
                    text.text = "";
                }
            }
        }
    }
}
