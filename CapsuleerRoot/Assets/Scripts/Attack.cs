using UnityEngine;

public class Attack : MonoBehaviour
{
    public float actualDamage, baseDamage;
    public float actualAttackSpeed, baseAttackSpeed;
    float attackCoolDown;
    public float actualRange, baseRange;
    public GameObject target;

    public virtual void Awake()
    {
        actualDamage = baseDamage;
        actualAttackSpeed = baseAttackSpeed;
        actualRange = baseRange;
        attackCoolDown = 0;
    }
    void Update()
    {
        if (attackCoolDown > 0)
            attackCoolDown -= Time.deltaTime;

        if(target != null)
        {
            if (Vector3.Distance(transform.position, target.transform.position) <= actualRange)
                AttackTarget();
        }
    }
    public virtual void AttackTarget()
    {
        //If player (SOMEHOW) desn't has health OR attack is not ready there is nothing to do. Back
        if (!target.GetComponent<Health>() || attackCoolDown > 0)
            return;
        else
        {
            GetComponent<Renderer>().material.color = Color.red;
            Vector3 lookDir = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z); //Look at enemy when attacking!
            transform.LookAt(lookDir);
            target.GetComponent<Health>().TakeDamage(actualDamage); //Send some damage!
            attackCoolDown = actualAttackSpeed; //Take a rest.
        }
    }
}
