using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Health
{

    public override void Die()
    {
        GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().isAlive = false;
        base.Die();
    }
}
