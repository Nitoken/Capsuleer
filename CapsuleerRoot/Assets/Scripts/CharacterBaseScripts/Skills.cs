using System.Collections.Generic;
using UnityEngine;

public class Skills : MonoBehaviour
{
    public enum Status:byte {coolDown = 0, ready = 1, use = 2} 
    public SkillObject selectedSkill;
    public List<SkillObject> skills; // Selected by player skills

    public virtual void Awake()
    {
        skills = new List<SkillObject>();
    }

    public virtual void SetupSkills(List<SkillObject> list)
    {
        foreach (SkillObject item in list)
            skills.Add(Instantiate(item)); //Won't affect Rest of scriptableObjects
        foreach (SkillObject item in skills)
            item.parent = gameObject.transform; //Whos your daddy?
    }

    public virtual void Update()
    {
        foreach (SkillObject item in skills)
        {
            if (item.actualCoolDown > 0)
            {
                item.actualCoolDown -= Time.deltaTime;
                item.status = (int)Status.coolDown;
            }
            else
            {
                if (item == selectedSkill)
                    item.status = (int)Status.use;
                if(item != selectedSkill)
                    item.status = (int)Status.ready;
            }
        }
    }
}
