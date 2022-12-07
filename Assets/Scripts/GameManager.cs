using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Runtime.CompilerServices;
using UnityEditor.UIElements;
using UnityEngine.SceneManagement;
using System.ComponentModel;

public class GameManager : MonoBehaviour
{    
    public static GameManager instance;

    // in game items
    public GameObject flashlightObject;
    public GameObject actualFlashlightLight;

    // battery textmesh
    public TextMeshProUGUI batteryCountTextMesh;
    public TextMeshProUGUI batteryLevelTextMesh;

    // player inventory variables
    public bool hasFlashlight;
    public bool hasKey;
    public int batteryCount;
    public float batteryLevel;

    // enemy variables
    public bool chasePlayer;

    // enviromental objects
    public Material materialDay;
    public Material materialNight;

    // environmental settings
    public bool setNightTime;
    public float sensex;
    public float sensey;
    

    void Awake(){
        // initialise gamemanager object variables
        instance = this;
        if(setNightTime){
            RenderSettings.skybox = materialNight;
        }else{
            RenderSettings.skybox = materialDay;
        }
        DontDestroyOnLoad(gameObject);

        // initialise game setting variables
        //sensex = SetSense.Instance.xval; ---- this messes with the script and doesnt allow the fixed update function to run as some errors popup, need to fix that before being able to uncomment
        //sensey = SetSense.Instance.yval;

        // initialise player variables
        hasFlashlight = false;
        hasKey = false;
        batteryCount = 0;
        batteryLevel = 100f;

        batteryCountTextMesh.text = "";
        batteryLevelTextMesh.text = "";

        // initialise enemy variables
        chasePlayer = false;
    }

    // Start is called before the first frame update
    void Start()
    {
         
    }

    void FixedUpdate(){
        print("running in fixedupdate");
        if(batteryLevel > 0 && actualFlashlightLight.active){
            batteryLevel -= 0.02f;
        }

        if(hasFlashlight){
            batteryCountTextMesh.text = batteryCount.ToString();
            batteryLevelTextMesh.text = ((int)batteryLevel).ToString();
        }

        print(batteryCountTextMesh.text);
        print(batteryLevelTextMesh.text);

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
            case "Battery":
                batteryCount++;
                print("picked up battery");
                break;
            default:
                print("Picked up an unidentified object!");
                break;
        }

    }

    public void PlayerDeath(){
        SceneManager.LoadScene("GameOverScene");
    }
}
