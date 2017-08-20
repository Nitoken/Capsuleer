using UnityEngine;

public class Health : MonoBehaviour
{
    public float hp, maxHP;
    public float actualDef, baseDef;
    public GameObject dieParticle;

    public virtual void Awake()
    {
        hp = maxHP;
        actualDef = baseDef;
    }
    public void TakeDamage(float damage)
    {
        hp -= damage / actualDef;

        if (hp <= 0)
            Die();
    }
    public void Heal(float heal)
    {
        hp += heal;
        if (hp > maxHP)
            hp = maxHP;
    }
    public virtual void Die()
    {
        Destroy(gameObject);
    }
}
