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


    void FixedUpdate()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        text.text = "";
        if (Physics.Raycast(ray, out hit, rayDistance))
        {

            if (hit.collider.tag == "Key")
            {
                text.text = "press E to pickup key";
                if (Input.GetKeyDown(presskey))
                {
                    Destroy(hit.collider.gameObject);
                    text.text = "";
                }
            }
        }
    }
}
