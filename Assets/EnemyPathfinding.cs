using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathfinding : MonoBehaviour
{
    public UnityEngine.AI.NavMeshAgent agent;

    public float radius;
    [Range(0,360)]
    public float angle;
    public GameObject playerRef;

    public LayerMask targetMask;
    public LayerMask obstructionMask;
    public Animator animator;
    public Transform player;
    public AudioSource audio;
    public AudioSource footsteps;

    public bool canSeePlayer;
    bool audioPlayed = false;
    bool killigplayer = false;

    public List<GameObject> waypoints;
    private int index = 0;


    private void Start(){
        playerRef = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(FOVRoutine());
    }

    private IEnumerator FOVRoutine(){
        float delay = 0.2f;
        WaitForSeconds wait = new WaitForSeconds(delay);

        while(true){
            yield return wait;
            FieldOfViewCheck();
        }
    }

    private void FieldOfViewCheck(){
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, radius, targetMask);

        if(rangeChecks.Length != 0){
            Transform target = rangeChecks[0].transform;
            Vector3 directionToTarget = (target.position - transform.position).normalized;

            if(Vector3.Angle(transform.forward, directionToTarget) < angle / 2){
                float distanceToTarget = Vector3.Distance(transform.position, target.position);

                if(!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionMask)){
                    canSeePlayer = true;
                    print("FOUND PLAYER!!!");
                }else{
                    canSeePlayer = false;
                }
            }else{
                canSeePlayer = false;
            }
        }else if(canSeePlayer){
            canSeePlayer = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!killigplayer)
        {
            animator.SetTrigger("Walk");
            if (canSeePlayer && GameManager.instance.alive && !GameManager.instance.playerHiddenState)
            {
                Debug.Log("player is not hidden");

                if (audioPlayed == false)

                {
                    //animator.SetTrigger("Walk");
                    audio.Play();
                    footsteps.Play();
                    audioPlayed = true;
                }

                agent.SetDestination(playerRef.transform.position);
            }
            else
            {
                // waypoint routing
                GameManager.instance.chasePlayer = false;

                Vector3 destination = new Vector3(waypoints[index].transform.position.x, 0, waypoints[index].transform.position.z);
                if (new Vector3(transform.position.x, 0, transform.position.z) == destination)
                {
                    if (index == waypoints.Count - 1 && waypoints.Count > 0)
                    {
                        index = 0;
                    }
                    else
                    {
                        index += 1;
                        print($"current index: {index}");
                    }
                }
                agent.SetDestination(destination);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        GameManager.instance.alive = false;
        InvokeRepeating("Die", 2.0f, 0.3f);
        animator.ResetTrigger("Walk");
        animator.SetTrigger("Kill");
        print("enemy hit a collider!");
        killigplayer = true;

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