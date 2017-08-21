using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerSkills : Skills
{
    public int maxSkill = 0;
    public override void Update()
    {
        base.Update();

        if(selectedSkill != null && Input.GetButtonDown("RightMouse"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit, byte.MaxValue, GetComponent<PlayerController>().interactLayers))
            {
                //Is it a projectile?
                if ((selectedSkill as ThrowSkillObject).isProjectile)
                    (selectedSkill as ThrowSkillObject).ProjectileThrow();
                //if not is target in range?
                else if (Vector3.Distance(transform.position, hit.point) <= selectedSkill.throwRange)
                    (selectedSkill as ThrowSkillObject).Throw(hit.point); //If code reach that point it should be obvious selected is throwable
            }
        }

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
