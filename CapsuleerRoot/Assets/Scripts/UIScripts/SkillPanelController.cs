//Used In SkillPanel UI
using UnityEngine;

public class SkillPanelController : MonoBehaviour
{
    PlayerSkills ps;
    public GameObject skillCell;
    public void Setup()
    {
        ps = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerSkills>();

        for (int i = 0; i < ps.skills.Count; i++)
        {
            GameObject x = Instantiate(skillCell, transform);
            x.GetComponent<SkillCellController>().skillNumber = ps.skills[i].skillID;
            x.GetComponent<SkillCellController>().ps = ps;
        }
    }
}
