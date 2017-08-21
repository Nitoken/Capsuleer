using UnityEngine;

[CreateAssetMenu]
public class ThrowSkillObject : SkillObject
{
    [Tooltip("Just for projectiles")]
    public float speed;
    public bool isThrowable = true; //Every throwable is throwable
    public bool isProjectile; //not every throwable is projectile. Check if it is.
    public override void Use()
    {
        base.Use();
        if (parent.GetComponent<Skills>().selectedSkill == this)
        {
            parent.GetComponent<Skills>().selectedSkill = null;
        }
        else
            parent.GetComponent<Skills>().selectedSkill = this;
    }
    public void Throw(Vector3 position)
    {
        Debug.Log("A");
        GameObject x = Instantiate(skill, position, skill.transform.rotation);
        Destroy(x, duration);
        SetCoolDown();
    }
    //EveryProjectile
    public void ProjectileThrow()
    {
        Vector3 pos = parent.transform.position;
        pos.y++;
        GameObject x = Instantiate(skill, pos, Quaternion.Euler(parent.forward));
        x.GetComponent<Rigidbody>().velocity = x.transform.forward.normalized * speed;
        Destroy(x, duration);
        SetCoolDown();
    }
}
