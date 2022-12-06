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

    // player inventory variables
    public bool hasFlashlight;
    public bool hasKey;

    // enemy variables
    public bool chasePlayer;

    // enviromental objects
    public Material materialDay;
    public Material materialNight;

    // environmental settings
    public bool setNightTime;
    public float sensex = 200;
    public float sensey = 200;
    

    void Awake(){
        instance = this;
        chasePlayer = false;
        if(setNightTime){
            RenderSettings.skybox = materialNight;
        }else{
            RenderSettings.skybox = materialDay;
        }
        DontDestroyOnLoad(gameObject);
        //sensex = SettingControll.Instance.xsense;
        //sensey = SettingControll.Instance.ysense;
        Debug.Log(PlayerPrefs.GetFloat("XSensitivity"));
    }

    // Start is called before the first frame update
    void Start()
    {
         
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

    public void PlayerDeath(){
        SceneManager.LoadScene("GameOverScene");
    }
}
