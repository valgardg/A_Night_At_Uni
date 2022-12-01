using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform player;
    public UnityEngine.AI.NavMeshAgent agent;

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(new Vector3(player.position.x, 2, player.position.z));
    }
}
