using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Runtime.CompilerServices;
using UnityEditor.UIElements;

public class collectableItemScript : MonoBehaviour
{
    public KeyCode presskey;
    public int rayDistance;
    public AudioSource audioSource;

    private TMP_Text defaultText;
    private TMP_Text itemText;

    void Start(){
        defaultText = GameObject.Find("ItemText").GetComponent<TextMeshProUGUI>();
        itemText = defaultText;
    }

    void FixedUpdate()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        itemText.text = "";
        if (Physics.Raycast(ray, out hit, rayDistance))
        {

            if (hit.collider.tag != "Untagged" && hit.collider.tag != "Door")
            {
                //GameManager.instance.UpdateTextPrompt(hit.collider.tag, "press E to pickup " + hit.collider.tag);
                itemText.text = "press E to pickup " + hit.collider.tag;
               
                if (Input.GetKey(presskey) && hit.collider.tag == gameObject.tag)
                {
                    audioSource.Play();
                    itemText.text = "";
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
