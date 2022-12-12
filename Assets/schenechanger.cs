using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Runtime.CompilerServices;
using UnityEditor.UIElements;

public class schenechanger : MonoBehaviour
{
    public GameObject player;
    public GameObject destination;
    public AudioClip monstersound;

    public TMP_Text text;
    public KeyCode presskey;
    public int rayDistance;

    void FixedUpdate()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        text.text = "";
        if (Physics.Raycast(ray, out hit, rayDistance))
        {
            if (hit.collider.tag == "elevatorDown")
            {
                if(GameManager.instance.powerOn){
                    text.text = "";
                }else{
                    text.text = "Press E to go upstairs";
                }

                if (Input.GetKeyDown(presskey))
                {
                    player.transform.position = new Vector3(144.65f,player.transform.position.y,-52.12f);
                }
            }
        }
    }
}
