using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Runtime.CompilerServices;
using UnityEditor.UIElements;

public class ElevatorScript : MonoBehaviour
{
    
    public TMP_Text text;
    private bool hasEntered;

    void Start(){
        hasEntered = false;
    }

    void FixedUpdate(){
        if(hasEntered && Input.GetKey("e")){
            SceneManager.LoadScene("basement");
        }
    }

    private void OnTriggerEnter(Collider other){
        text.text = "Press E to go to basement";
        hasEntered = true;
    }
}
