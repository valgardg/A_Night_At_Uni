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
        Debug.Log(animator);
        if (animator.tag == "Done")
            GameManager.instance.PlayerDeath();

        Debug.Log(GameManager.instance.alive);
        if (GameManager.instance.alive)
        {
            if (GameManager.instance.chasePlayer)
            {

                //agent.SetDestination(new Vector3(player.position.x, 2, player.position.z));
                Debug.Log("should Walk");

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
        InvokeRepeating("Die", 2.0f, 0.3f);
        animator.ResetTrigger("Walk");
        animator.SetTrigger("Kill");
        print("enemy hit a collider!");
        //GameManager.instance.PlayerDeath();
    }

    private void OnTriggerStay(Collider other)
    {
        Vector3 direction = player.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, 5f * Time.deltaTime);
    }

    private void Die()
    {
        GameManager.instance.PlayerDeath();
    }

}