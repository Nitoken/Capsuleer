using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : Movement
{
    NavMeshAgent agent;
    public GameObject player;
    Attack ea;
    public override void Awake()
    {
        base.Awake();
        ea = GetComponent<Attack>();
        player = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
        ea.target = player;
    }
    void Update()
    {
        agent.speed = actualSpeed;
        if (player != null)
        {
            if (Vector3.Distance(transform.position, player.transform.position) > ea.actualRange)
            {
                actualStatus = Status.attack;
                agent.SetDestination(player.transform.position);
            }
            else
                agent.SetDestination(transform.position);
        }
        else
            actualStatus = Status.stay;
    }
}
