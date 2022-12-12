using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Runtime.CompilerServices;
using UnityEditor.UIElements;

public class PowerScript : MonoBehaviour
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
            if (hit.collider.tag == "Power")
            {
                if(GameManager.instance.powerOn){
                    text.text = "";
                }else{
                    text.text = "Press E to turn the power on";
                }

                if (Input.GetKeyDown(presskey))
                {
                    GameManager.instance.powerOn = true;
                    print("power was turned on");
                }
            }
        }
    }
}
