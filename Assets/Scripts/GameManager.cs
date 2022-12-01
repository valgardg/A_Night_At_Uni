using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool chasePlayer;

    // player inventory variables
    public bool hasFlashlight;
    public bool hasKey;

    void Awake(){
        instance = this;
        chasePlayer = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        print("running running running!");   
    }
}
