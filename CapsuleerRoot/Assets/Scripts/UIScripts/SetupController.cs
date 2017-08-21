using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class SetupController : MonoBehaviour
{
    public int maxSelected; //How many skills can peek player? preffer max 9 (cuz UI), but yeah. It depends what you want
    public Text txt; //Text that shows actual status
    public GameObject cell; //Skill select cell
    public Transform parent; // Where put cells
    public List<SkillObject> skillList; // List available skills
    public List<SkillObject> selectedSkills; // List selected skills
    public GameObject player, skillPanel, waveController;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Setup();
    }

    void Update()
    {
        txt.text = string.Format("You got {0}/{1} skills", selectedSkills.Count, maxSelected);
    }
    //Create panel which contains skills to select
    void Setup()
    {

        foreach (SkillObject item in skillList)
        {
            Transform x = Instantiate(cell, parent).transform;
            x.GetChild(0).GetComponent<Image>().sprite = item.icon;
            x.GetChild(1).GetComponent<Text>().text = item.skillName;
            x.GetChild(2).GetComponent<Text>().text = item.skillDesc;
            x.GetChild(3).GetComponent<Button>().onClick.AddListener(() => Add(item.skillID));
            x.GetChild(4).GetComponent<Button>().onClick.AddListener(() => RemoveSkill(item.skillID));
        }
    }

    //Called by button
    public void Save()
    {
        //You have to take at least one skill
        if (selectedSkills.Count < 1)
            return;

        player.GetComponent<PlayerSkills>().SetupSkills(selectedSkills); //Add selected skills to player
        player.GetComponent<PlayerSkills>().maxSkill = maxSelected; //iteration has to know how long it can move
        player.GetComponent<Rigidbody>().isKinematic = false; //Player can move now
        skillPanel.GetComponent<SkillPanelController>().Setup(); //Set selected skills on UI
        waveController.GetComponent<WavePanelController>().startBTN.GetComponent<Button>().interactable = true; //new wave button is now active
        GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().setupDone = true;
        GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().improvePanel.GetComponent<ImprovePanelController>().freeSkill += 3;
        gameObject.SetActive(false); //Turn off panel

    }
    //Called by button
    public void Return()
    {
        selectedSkills.Clear();
    }
    //Called by button
    void Add(int ID)
    {
        if (selectedSkills.Count >= maxSelected)
            return;

        //In other way (implemented in second foreach here) script wont work (wont add to button OnClick). Bug?
        foreach (SkillObject item in selectedSkills)
            if(item.skillID == ID)
                if (selectedSkills.Contains(item))
                    return;

        foreach (SkillObject item in skillList)
        {
            if (item.skillID == ID)
            {
                selectedSkills.Add(item);
                break;
            }
        }
    }
    //Called by button
    public void RemoveSkill(int ID)
    {
        foreach (SkillObject item in selectedSkills)
        {
            if (item.skillID == ID)
            {
                selectedSkills.Remove(item);
                break;
            }
        }
    }
}
