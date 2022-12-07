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
        if (PlayerPrefs.GetInt("NormalDifficulty") == 1)
        {
            if (GameManager.instance.chasePlayer)
            {
                agent.SetDestination(new Vector3(player.position.x, 2, player.position.z));
                if (audioPlayed == false)
                {
                    audio.Play();
                    footsteps.Play();
                    audioPlayed = true;
                }
            }
        }
        else
        {
            // we can make some difficulty changes here if we want.
        }
    }

    private void OnTriggerEnter(Collider other){
        print("enemy hit a collider!");
        GameManager.instance.PlayerDeath();
    }
}