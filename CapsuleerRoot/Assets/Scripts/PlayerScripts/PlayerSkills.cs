using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkills : Skills
{
    public Sprite[] skillIcon;
    public override void Update()
    {
        if (Input.GetButtonDown("FirstUse"))
            FirstSkillUse();
        if (Input.GetButtonDown("SecondUse"))
            SecondSkillUse();
        if (Input.GetButtonDown("ThirdUse"))
            ThirdSkillUse();
        if (Input.GetButtonDown("FourthUse"))
            FourthSkillUse();

        base.Update();
    }
    public override void FirstSkillUse()
    {
        if (coolDown[0] > 0)
            return;

        GameObject x = Instantiate(skill[0], transform.position, skill[0].transform.rotation);
        x.transform.SetParent(gameObject.transform);
        x.GetComponent<BaseAuraSkill>().level = skillLevel[0];
        coolDown[0] = baseCoolDown[0];
    }
    public override void SecondSkillUse()
    {
        if (coolDown[1] > 0)
            return;

        GameObject x = Instantiate(skill[1], transform.position, skill[1].transform.rotation);
        x.transform.SetParent(gameObject.transform);
        x.GetComponent<BaseAuraSkill>().level = skillLevel[1];
        coolDown[1] = baseCoolDown[1];
    }
    public override void ThirdSkillUse()
    {
        if (coolDown[2] > 0)
            return;

        GameObject x = Instantiate(skill[2], transform.position, skill[2].transform.rotation);
        x.transform.SetParent(gameObject.transform);
        x.GetComponent<BaseAuraSkill>().level = skillLevel[2];
        coolDown[2] = baseCoolDown[2];
    }
    public override void FourthSkillUse()
    {
        if (coolDown[3] > 0)
            return;

        GameObject x = Instantiate(skill[3], transform.position, skill[3].transform.rotation);
        x.transform.SetParent(gameObject.transform);
        x.GetComponent<BaseAuraSkill>().level = skillLevel[3];
        coolDown[3] = baseCoolDown[3];
    }
}
