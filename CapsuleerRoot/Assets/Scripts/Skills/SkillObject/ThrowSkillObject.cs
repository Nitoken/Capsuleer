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
        else if(this.actualCoolDown <=0)
            parent.GetComponent<Skills>().selectedSkill = this;
    }
    public void Throw(Vector3 position)
    {
        GameObject x = Instantiate(skill, position, skill.transform.rotation);
        x.GetComponent<BaseSkill>().caster = parent.gameObject; //Who is caster?
        x.GetComponent<BaseSkill>().level = this.level; //Which level?
        x.GetComponent<BaseSkill>().baseValue = this.basicValue; //How strong is effect?
        Destroy(x, duration);
        SetCoolDown();
    }
    //EveryProjectile
    public void ProjectileThrow(Vector3 direction)
    {
        Vector3 pos = parent.transform.position;
        pos.y++;
        GameObject x = Instantiate(skill, pos, Quaternion.Euler(parent.forward));
        x.GetComponent<BaseSkill>().caster = parent.gameObject; //Who is caster?
        x.GetComponent<BaseSkill>().level = this.level; //Which level?
        x.GetComponent<BaseSkill>().baseValue = this.basicValue; //How strong is effect?
        x.GetComponent<Rigidbody>().velocity = direction * speed;
        Destroy(x, duration);
        SetCoolDown();
    }
}
