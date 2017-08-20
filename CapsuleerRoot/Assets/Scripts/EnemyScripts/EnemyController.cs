using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : Movement
{
    NavMeshAgent agent;
    public GameObject player;
    UpperPanelController upc;
    public bool isDead = false;
    public override void Awake()
    {
        base.Awake();
        upc = GameObject.FindGameObjectWithTag("UPC").GetComponent<UpperPanelController>();
        player = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
        atk.target = player;
    }
    void Update()
    {
        agent.speed = actualSpeed; //Send speed to agent

        if (player != null)
        {
            //if too far away then get closer
            if (Vector3.Distance(transform.position, player.transform.position) > atk.actualRange)
            {
                actualAnimStatus = AnimStatus.move;
                actualStatus = Status.attack;
                agent.SetDestination(player.transform.position);
            }
            else
            {
                actualAnimStatus = AnimStatus.attack;
                agent.SetDestination(transform.position); //if close enought stop
            }
        }
        else
        {
            actualAnimStatus = AnimStatus.idle;
            actualStatus = Status.stay;
        }

        anim.SetInteger("Status", (int)actualAnimStatus);
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
