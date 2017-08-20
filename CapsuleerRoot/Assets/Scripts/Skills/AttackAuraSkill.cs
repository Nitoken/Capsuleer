using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAuraSkill : BaseAuraSkill
{
    public override void Start()
    {
        caster = gameObject.transform.parent.gameObject;
        valueChange = caster.GetComponent<Attack>().actualDamage + baseValue * level;
        caster.GetComponent<Attack>().actualDamage += valueChange;
    }

    void OnDestroy()
    {
        caster.GetComponent<Attack>().actualDamage -= valueChange;
    }
}
