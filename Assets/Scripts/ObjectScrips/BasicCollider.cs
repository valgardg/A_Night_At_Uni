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
    public AudioSource audioSource;

    void FixedUpdate()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        text.text = "";
        if (Physics.Raycast(ray, out hit, rayDistance))
        {

            if (hit.collider.tag != "Untagged" && hit.collider.tag != "Door")
            {
                //GameManager.instance.UpdateTextPrompt(hit.collider.tag, "press E to pickup " + hit.collider.tag);
                text.text = "press E to pickup " + hit.collider.tag;
               
                if (Input.GetKey(presskey) && hit.collider.tag == gameObject.tag)
                {
                    audioSource.Play();
                    text.text = "";
                    GameManager.instance.ItemPickedUp(hit.collider.tag);
                    //hit.collider.gameObject.SetActive(false);
                    Destroy(hit.collider.gameObject);
                }
            }
        }
    }
    private void OnDestroy()
    {
       
    }
}
