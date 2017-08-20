using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skills : MonoBehaviour
{
    public float[] coolDown, baseCoolDown;
    public int[] skillLevel, skillStatus;
    public enum Status:byte {coolDown = 0, ready = 1, use = 2}
    public GameObject[] skill;
    
    public virtual void Update()
    {
        for(int i = 0; i < coolDown.Length; i++)
        {
            if (coolDown[i] >= 0)
            {
                coolDown[i] -= Time.deltaTime;
                if(skillStatus[i] != (int)Status.use)
                    skillStatus[i] = (int)Status.coolDown;
            }
            else
            {
                if (skillStatus[i] != (int)Status.use)
                    skillStatus[i] = (int)Status.ready;
            }
        }
    }

    public virtual void FirstSkillUse()
    {

    }
    public virtual void SecondSkillUse()
    {

    }
    public virtual void ThirdSkillUse()
    {

    }
    public virtual void FourthSkillUse()
    {

    }
}
