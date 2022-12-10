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

    public bool canSeePlayer;

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
        if(canSeePlayer){
            agent.SetDestination(playerRef.transform.position);
        }else{
            // waypoint routing
            Vector3 destination = new Vector3(waypoints[index].transform.position.x, 0, waypoints[index].transform.position.z);
            if(new Vector3(transform.position.x, 0, transform.position.z) == destination){
                if(index == waypoints.Count && waypoints.Count > 0){
                    index = 0;
                }else{
                    index += 1;
                }
            }
            agent.SetDestination(destination); 
        }
    }
}