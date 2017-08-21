using UnityEngine;

public class ProjectileSkill : BaseSkill
{
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Enemy")
        {
            if (col.GetComponent<EnemyHealth>())
            {
                col.GetComponent<EnemyHealth>().TakeDamage(baseValue);
                Destroy(gameObject);
            }
        }
    }
}
