//Base of all skills. Contains basic stats.
using UnityEngine;

public class SkillObject : ScriptableObject
{
    public int skillID;
    public float throwRange = 0;
    public Sprite icon;
    public string skillName;
    public string skillDesc;
    public int level;
    public int status = 1;
    public float coolDown, actualCoolDown = 0;
    public GameObject skill;
    public Transform parent;
    public float duration = 10;
    [Tooltip("How strong is effect?")]
    public float basicValue; //Can be damage, % bonus etc. Depends

    public virtual void Use()
    {

    }
    public void SetCoolDown()
    {
        foreach (SkillObject item in parent.GetComponent<Skills>().skills)
        {
            if (item == this)
            {
                item.actualCoolDown = item.coolDown;
                break;
            }
        }
    }
}
