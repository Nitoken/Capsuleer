using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowAreaDamageSkill : BaseSkill
{
    void OnTriggerStay(Collider col)
    {
        if(col.gameObject != caster)
        {
            if (col.gameObject.GetComponent<Health>())
                col.gameObject.GetComponent<Health>().TakeDamage(baseValue * Time.deltaTime);
        }
    }
}
