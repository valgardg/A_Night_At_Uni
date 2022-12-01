using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Runtime.CompilerServices;
using UnityEditor.UIElements;

public class GameManager : MonoBehaviour
{    
    public static GameManager instance;

    // in game items
    public GameObject flashlightObject;
    public GameObject actualFlashlightLight;

    // player inventory variables
    public bool hasFlashlight;
    public bool hasKey;

    public bool chasePlayer;
    
    public TMP_Text text;
    private string currentOrigin;
    
    void Awake(){
        instance = this;
        chasePlayer = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        text.text = "";
    }

    public void UpdateTextPrompt(string origin, string incomingText){
        if(currentOrigin == origin && incomingText == null){
            text.text = null;
        }
        if(text is not null){
            print("should be updating now!!!");
            currentOrigin = origin;
            text.text = incomingText;
        }

    }

    // Update is called once per frame
    void Update()
    {  
        
    }

    public void ItemPickedUp(string pickedUpItem){
        
        switch(pickedUpItem){
            case "Key":
                hasKey = true;
                print("picked up key!");
                break;
            case "Flashlight":
                hasFlashlight = true;
                flashlightObject.active = true;
                actualFlashlightLight.active = false;
                print("picked up flashlight!");
                break;
            default:
                print("Picked up an unidentified object!");
                break;
        }

    }
}
