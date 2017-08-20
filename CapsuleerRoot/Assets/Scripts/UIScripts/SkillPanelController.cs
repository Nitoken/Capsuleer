using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillPanelController : MonoBehaviour
{
    PlayerSkills ps;
    public GameObject skillCell;
    void Awake()
    {
        ps = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerSkills>();
        for (int i = 0; i < ps.skill.Length; i++)
        {
            GameObject x = Instantiate(skillCell, transform);
            x.GetComponent<SkillCellController>().skillNumber = i;
            x.GetComponent<SkillCellController>().ps = ps;
        }
    }
}
