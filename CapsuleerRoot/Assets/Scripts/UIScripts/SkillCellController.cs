using UnityEngine.UI;
using UnityEngine;

public class SkillCellController : MonoBehaviour
{
    public int skillNumber;
    public PlayerSkills ps;
    public SkillObject so;
    GameController gc;
    Image img;
    Text status;
    Image bar;
    int stat; // {coolDown = 0, ready = 1, use = 2}

    void Start ()
    {
        foreach (SkillObject item in ps.skills)
            if (item.skillID == skillNumber)
                so = item;


        gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        img = transform.GetChild(0).GetComponent<Image>();
        status = transform.GetChild(1).GetComponent<Text>();
        bar = transform.GetChild(2).GetComponent<Image>();

        img.sprite = so.icon;
    }

	void Update ()
    {
        if(gc.isAlive)
        {
            foreach(SkillObject item in ps.skills)
            {
                if(item == so)
                {
                    stat = item.status;
                    bar.fillAmount = item.actualCoolDown / item.coolDown;
                }
            }

            switch(stat)
            {
                case 0:
                    status.color = Color.red;
                    status.text = "Cooldown";
                    break;
                case 1:
                    switch(skillNumber)
                    {
                        case 0:
                            status.text = "Q";
                            break;
                        case 1:
                            status.text = "W";
                            break;
                        case 2:
                            status.text = "E";
                            break;
                        case 3:
                            status.text = "R";
                            break;
                    }
                    status.color = Color.green;
                    break;
                case 2:
                    status.color = Color.yellow;
                    break;
            }


        }
	}
}
