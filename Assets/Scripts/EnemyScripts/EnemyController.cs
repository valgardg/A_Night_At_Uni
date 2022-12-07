using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform player;
    public UnityEngine.AI.NavMeshAgent agent;
    public AudioSource audio;
    public AudioSource footsteps;

    bool audioPlayed = false;

    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.chasePlayer && !GameManager.instance.playerHiddenState){
            agent.SetDestination(new Vector3(player.position.x, 2, player.position.z));
            if(audioPlayed == false){
                audio.Play();
                footsteps.Play();
                audioPlayed = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other){
        print("enemy hit a collider!");
        GameManager.instance.PlayerDeath();
    }
}