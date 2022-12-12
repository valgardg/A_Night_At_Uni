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

    public GameObject playerBody;
    public GameObject playerobject;

    // battery textmesh
    public TextMeshProUGUI batteryCountTextMesh;
    public TextMeshProUGUI batteryLevelTextMesh;

    // player hidden textmesh
    public TextMeshProUGUI hideTextMesh;

    // player inventory variables
    public bool hasFlashlight;

    // -- keys
    public bool hasStartRoomKey;
    public bool hasSlidingDoorKey;
    
    public int batteryCount;
    public float batteryLevel;
    public float batteryDrainSpeed;

    //player states
    public bool playerHiddenState;
    private Vector3 previousPlayerPosition;

    // enemy variables
    public bool chasePlayer;

    // enviromental objects
    public Material materialDay;
    public Material materialNight;

    // environmental settings
    public bool setNightTime;
    public float sensex = 200;
    public float sensey = 200;
    public bool alive = true;
    

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

        playerHiddenState = false;

        hasFlashlight = false;
        hasStartRoomKey= false;
        hasSlidingDoorKey = false;
        batteryCount = 0;
        batteryLevel = 100f;
        batteryDrainSpeed = 0.02f;

        batteryCountTextMesh.text = "";
        batteryLevelTextMesh.text = "";

        // initialise enemy variables
        chasePlayer = false;

        
        //sensex = SettingControll.Instance.xsense;
        //sensey = SettingControll.Instance.ysense;
        Debug.Log(PlayerPrefs.GetFloat("XSensitivity"));
    }

    // Start is called before the first frame update
    void Start()
    {
         
    }

    void FixedUpdate(){
        // hide stuff
        if(playerHiddenState){
            hideTextMesh.text = "press e to stop hiding";
            if(Input.GetKey("w")){
                unhidePlayer();
            }
        }

        // battery stuff
        if(batteryLevel > 0 && actualFlashlightLight.active){
            batteryLevel -= batteryDrainSpeed;
        }

        if(batteryLevel < 0.1){
            actualFlashlightLight.active = false;
        }

        if(hasFlashlight){
            batteryCountTextMesh.text = batteryCount.ToString();
            batteryLevelTextMesh.text = ((int)batteryLevel).ToString() + "%";
        }

    }

    public void ItemPickedUp(string pickedUpItem){
        
        switch(pickedUpItem){
            case "Key":
                hasStartRoomKey = true;
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
            case "SlidingDoorKey":
                hasSlidingDoorKey = true;
                break;
            default:
                print("Picked up an unidentified object!");
                break;
        }

    }

    public void PlayerDeath(){
        SceneManager.LoadScene("GameOverScene");
    }

    public void hidePlayer(Vector3 hidePosition){
        print("player hides");
        playerHiddenState = true;
        playerBody.active = false;
        previousPlayerPosition = playerobject.transform.position;
        playerobject.transform.position = hidePosition;
    }

    public void unhidePlayer(){
        print("player stops hiding");
        playerHiddenState = false;
        playerobject.transform.position = previousPlayerPosition;
        playerBody.active = true;
    }
}
