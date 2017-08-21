using UnityEngine;
using System.Collections.Generic;
public class Attack : MonoBehaviour
{
    public float actualDamage, baseDamage;
    public float actualAttackSpeed, baseAttackSpeed;
    public float actualRange, baseRange;
    public GameObject target; //Attack it

    public AnimationClip attackClip; //Which script shoud contain event
    public float animDealDamageTime; //Whean deal damage
    Animator anim; //To set damage script

    public LayerMask canHurt; //Which targets can be hurt? Used in skill system

    public virtual void Awake()
    {
        anim = GetComponent<Animator>();
        actualDamage = baseDamage;
        actualAttackSpeed = baseAttackSpeed;
        actualRange = baseRange;
        AddEvent();
    }
    void Update()
    {
        anim.SetFloat("AttackSpeed", actualAttackSpeed);
    }

    //Sets time for every selected animation when damage must be done
    void AddEvent()
    {
        foreach (AnimationClip item in anim.runtimeAnimatorController.animationClips)
        {
            if (item == attackClip)
            {
                if (attackClip.events .Length> 0)
                    return;

                AnimationEvent aev = new AnimationEvent();
                aev.functionName = "DealDamage";
                aev.time = attackClip.length * animDealDamageTime;
                item.AddEvent(aev);
            }

        }
    }
    public void DealDamage()
    {
        if(target != null)
            target.GetComponent<Health>().TakeDamage(actualDamage);
    }

}
