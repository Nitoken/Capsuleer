using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : Movement
{
    NavMeshAgent agent;
    public GameObject player;
    Attack ea;
    UpperPanelController upc;
    public override void Awake()
    {
        base.Awake();
        upc = GameObject.FindGameObjectWithTag("UPC").GetComponent<UpperPanelController>();
        ea = GetComponent<Attack>();
        player = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
        ea.target = player;
    }
    void Update()
    {
        agent.speed = actualSpeed; //Send speed to agent

        if (player != null)
        {
            //if too far away then get closer
            if (Vector3.Distance(transform.position, player.transform.position) > ea.actualRange)
            {
                actualStatus = Status.attack;
                agent.SetDestination(player.transform.position);
            }
            else
                agent.SetDestination(transform.position); //if close enought stop
        }
        else
            actualStatus = Status.stay;
    }

    //For showing actual HP
    void OnMouseOver()
    {
        if (upc.enemytoShow == null)
            upc.enemytoShow = gameObject;
    }
    void OnMouseExit()
    {
        //If panel shows actual player's target
        if (!upc.showingByPlayerAttack)
            upc.enemytoShow = null;
    }
}
