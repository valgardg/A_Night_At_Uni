using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Runtime.CompilerServices;
using UnityEditor.UIElements;

public class BasicCollider : MonoBehaviour
{
    public TMP_Text text;
    public KeyCode presskey;
    public int rayDistance;
    public GameObject mydoor;
    public Animation anitmate;

    void FixedUpdate()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        text.text = "";
        if (Physics.Raycast(ray, out hit, rayDistance))
        {

            if (hit.collider.tag != "Untagged" && hit.collider.tag != "Door")
            {
                text.text = "press E to pickup " + hit.collider.tag;
               
                if (Input.GetKeyDown(presskey))
                {                  
                    Destroy(hit.collider.gameObject);
                    text.text = "";
                }
            }
        }
    }
}
