using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float playerSpeed = 6f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("w")){
            print("player pressed w");
            gameObject.transform.Translate(0f,0f,playerSpeed * Time.deltaTime);
        }
        if(Input.GetKey("s")){
            print("player pressed s");
            gameObject.transform.Translate(0f,0f,-playerSpeed * Time.deltaTime);
        }
        if(Input.GetKey("a")){
            print("player pressed a");
            gameObject.transform.Translate(-playerSpeed * Time.deltaTime,0f,0f);
        }
        if(Input.GetKey("d")){
            print("player pressed d");
            gameObject.transform.Translate(playerSpeed * Time.deltaTime,0f,0f);
        }
    }
}
