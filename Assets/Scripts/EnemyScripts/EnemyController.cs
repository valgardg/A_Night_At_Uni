using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform player;
    public UnityEngine.AI.NavMeshAgent agent;
    public AudioSource audio;
    public AudioSource footsteps;
    public Animator animator;

    bool audioPlayed = false;

    // Update is called once per frame
    void Update()
    {

        if (GameManager.instance.alive)
        {
            if (GameManager.instance.chasePlayer && !GameManager.instance.playerHiddenState)
            {
                agent.SetDestination(new Vector3(player.position.x, 2, player.position.z));

                animator.SetTrigger("Walk");
                if (audioPlayed == false)
                {
                    //animator.SetTrigger("Walk");
                    audio.Play();
                    footsteps.Play();
                    audioPlayed = true;
                }

            }
        }
    }

    private void OnTriggerEnter(Collider other){
        GameManager.instance.alive = false;
        animator.ResetTrigger("Walk");
        print("enemy hit a collider!");
        GameManager.instance.PlayerDeath();
    }

}