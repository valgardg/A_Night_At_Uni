using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Runtime.CompilerServices;
using UnityEditor.UIElements;

public class ElevatorScript : MonoBehaviour
{
    public GameObject player;
    public GameObject destination;

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
            if (hit.collider.tag == "elevatoUp")
            {
                if(GameManager.instance.powerOn){
                    text.text = "";
                }else{
                    text.text = "Press E to go downstairs";
                }

                if (Input.GetKeyDown(presskey))
                {
                    player.transform.position = new Vector3(6.123096f,player.transform.position.y,10.06f);
                }
            }
        }
    }
}
