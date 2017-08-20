using UnityEngine;

public class Health : MonoBehaviour
{
    public float hp, maxHP;
    public float actualDef, baseDef;
    public GameObject dieParticle;
    [Tooltip("Die particle duration")]
    public float particleDuration;
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
        GameObject x = Instantiate(dieParticle, transform.position, dieParticle.transform.rotation);
        Destroy(x, particleDuration);
        Destroy(gameObject);
    }
}
