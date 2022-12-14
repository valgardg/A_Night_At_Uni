using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
            if (hit.collider.tag == "SlidingDoor")
            {
                if(!GameManager.instance.powerOn){
                    text.text = "turn the power on!";
                }else{
                    text.text = "press E to escape";
                }

                if (Input.GetKeyDown(presskey) && GameManager.instance.powerOn)
                {
                    SceneManager.LoadScene("Menu_Scene");
                }
            }
        }
    }
}
