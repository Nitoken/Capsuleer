using UnityEngine.UI;
using UnityEngine;
using System.Collections.Generic;
public class ImprovePanelController : MonoBehaviour
{
    GameObject player;
    public Transform parent;
    public GameObject skillCell;
    public Text txt;
    public float freeSkill = 0;
    public GameObject[] statImprove;
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void OnEnable()
    {
        Setup();
    }
    public void Setup()
    {
        //Collect data from player and show it
        txt.text = "Free points: " + freeSkill;
        statImprove[0].transform.GetChild(0).GetComponent<Text>().text = player.GetComponent<PlayerAttack>().baseAttackSpeed.ToString("f2");
        statImprove[1].transform.GetChild(0).GetComponent<Text>().text = player.GetComponent<PlayerAttack>().baseDamage.ToString("f2");
        statImprove[2].transform.GetChild(0).GetComponent<Text>().text = player.GetComponent<PlayerHealth>().maxHP.ToString("f2");
        statImprove[3].transform.GetChild(0).GetComponent<Text>().text = player.GetComponent<PlayerHealth>().baseDef.ToString("f2");
        statImprove[4].transform.GetChild(0).GetComponent<Text>().text = player.GetComponent<PlayerController>().baseSpeed.ToString("f2");

        //Clear all skills in panel (if exists). prevent from double skills
        if (parent.childCount > 0)
            foreach (Transform child in parent)
                Destroy(child.gameObject);

        //Set all skill to panel (clear, lol)
        foreach (SkillObject item in player.GetComponent<PlayerSkills>().skills)
        {
            Transform x = Instantiate(skillCell, parent).transform;
            x.GetChild(0).GetComponent<Image>().sprite = item.icon;
            x.GetChild(1).GetComponent<Text>().text = item.skillName;
            x.GetChild(2).GetComponent<Text>().text = item.level.ToString();
            x.GetChild(3).GetComponent<Button>().onClick.AddListener(() => ImproveSkill(item.skillID));
        }
    }
    //Called from button
    public void ImproveSkill(int ID)
    {
        //Can you afford improvement?
        if (freeSkill <= 0)
            return;

        //Find and improve
        foreach (SkillObject item in player.GetComponent<PlayerSkills>().skills)
            if (item.skillID == ID)
                item.level++;

        freeSkill--;
        Setup(); //Refresh window
    }
    //Called from button
    public void ImproveStat(int number)
    {
        //Can you afford improvement?
        if (freeSkill <= 0)
            return;

        //Find stat
        switch (number)
        {
            //Attack speed
            case 0:
                //Just don't fly away
                if (player.GetComponent<PlayerAttack>().baseAttackSpeed <= 3f)
                {
                    player.GetComponent<PlayerAttack>().baseAttackSpeed += 0.1f;
                    freeSkill--;
                }
                break;
            //Attack power
            case 1:
                player.GetComponent<PlayerAttack>().baseDamage++;
                freeSkill--;
                break;
            //Max hp
            case 2:
                player.GetComponent<PlayerHealth>().maxHP += 10;
                player.GetComponent<PlayerHealth>().hp = player.GetComponent<PlayerHealth>().maxHP;
                break;
            //Defense
            case 3:
                player.GetComponent<PlayerHealth>().baseDef++;
                freeSkill--;
                break;
            //Move speed
            case 4:
                //idk why. just because
                if (player.GetComponent<PlayerController>().baseSpeed <= 12)
                {
                    player.GetComponent<PlayerController>().baseSpeed++;
                    freeSkill--;
                }
                break;
        }
        Setup(); //Refresh window
    }
}
