using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform player;
    public UnityEngine.AI.NavMeshAgent agent;
    public AudioSource audio;
    public AudioSource footsteps;
    public Animator animator;
    private bool killplaying = false;

    bool audioPlayed = false;

    // Update is called once per frame

    private void Start()
    {
        //animator = GetComponent<Animator>();
        animator.ResetTrigger("Walk");
    }
    void Update()
    {
        if (!killplaying)
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
        killplaying = true;
        animator.ResetTrigger("Kill");
        print("enemy hit a collider!");
        animator.SetTrigger("Kill");
        //GameManager.instance.PlayerDeath();
    }
}