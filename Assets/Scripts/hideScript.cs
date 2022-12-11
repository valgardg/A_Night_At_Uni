using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Runtime.CompilerServices;
using UnityEditor.UIElements;

public class hideScript : MonoBehaviour
{
    public KeyCode presskey;
    public int rayDistance;
    public GameObject headLevel;

    private TMP_Text defaultText;
    private TMP_Text itemText;

    void Start(){
        defaultText = GameObject.Find("HideText").GetComponent<TextMeshProUGUI>();
        itemText = defaultText;
    }

    void FixedUpdate()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        itemText.text = "";
        if (Physics.Raycast(ray, out hit, rayDistance))
        {

            if (hit.collider.tag == "HideObject")
            {
                itemText.text = "press E to hide ";
            }
            if (hit.collider == gameObject.GetComponent<Collider>())
            {  
                if (Input.GetKeyDown(presskey) && hit.collider.tag == gameObject.tag)
                {
                    itemText.text = "";
                    GameManager.instance.hidePlayer(headLevel.transform.position);
                }
            }
        }
    }
}
