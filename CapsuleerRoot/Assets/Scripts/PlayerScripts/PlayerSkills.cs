﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerSkills : Skills
{
    public int maxSkill = 0; // just to know how many time iterate. Got this from Setup script
    public override void Update()
    {
        base.Update(); // Mainly cooldown skills 

        if(selectedSkill != null && Input.GetButtonDown("RightMouse"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit, byte.MaxValue, GetComponent<PlayerController>().interactLayers))
            {
                //Is it a projectile?
                if ((selectedSkill as ThrowSkillObject).isProjectile)
                {
                    Vector3 direction = hit.point - transform.position;
                    direction.y = 0; ;
                    print(direction.normalized);
                    (selectedSkill as ThrowSkillObject).ProjectileThrow(direction.normalized);
                }
                //if not is target in range?
                else if (Vector3.Distance(transform.position, hit.point) <= selectedSkill.throwRange)
                    (selectedSkill as ThrowSkillObject).Throw(hit.point); //If code reach that point it should be obvious selected is throwable
                selectedSkill = null;
            }
        }

        //Any key pressed?
        for(int i = 1; i <= maxSkill; i ++)
        {
            if (Input.GetButtonDown(i.ToString()))
                TurnOnSkill(i);
        }

    }
    void TurnOnSkill(int num)
    {
        skills[num-1].Use();
    }
}
