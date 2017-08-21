//Auras stick to caster position.

using UnityEngine;
[CreateAssetMenu]
public class AuraObject : SkillObject
{


    public override void Use()
    {
        GameObject x = Instantiate(skill,parent);
        x.GetComponent<BaseSkill>().caster = parent.gameObject; //Who is caster?
        x.GetComponent<BaseSkill>().level = this.level; //Which level?
        x.GetComponent<BaseSkill>().baseValue = this.basicValue; //How strong is effect?
        Destroy(x, duration); // When skill should be deployed
        SetCoolDown();
    }
}
