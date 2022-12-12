using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Runtime.CompilerServices;
using UnityEditor.UIElements;

public class SlidingDoorsScript : MonoBehaviour
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
            print("ray is hitting");
            if (hit.collider.tag == "SlidingDoor")
            {
                if(!GameManager.instance.hasSlidingDoorKey){
                    text.text = "press E to escape";
                }else{
                    text.text = "turn the power on";
                }

                if (Input.GetKeyDown(presskey) && GameManager.instance.hasSlidingDoorKey)
                {
                    print("you won the game!");
                }
            }
        }
    }
}
