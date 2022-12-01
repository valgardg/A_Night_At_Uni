using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseTriggerScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other){
        GameManager.instance.chasePlayer = true;
    }
}
