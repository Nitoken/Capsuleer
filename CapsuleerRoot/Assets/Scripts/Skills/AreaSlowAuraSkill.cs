using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Collider))]
public class AreaSlowAuraSkill : BaseSkill
{
    Dictionary<GameObject, float> targets;
    public override void Start()
    {
        base.Start();
        targets = new Dictionary<GameObject, float>();
    }
    // Check if GameObject is in dictionary, if not -> Save gameobject, slow him
    void OnTriggerEnter(Collider col)
    {
        //Don't slow caster, lol!
        if (col.gameObject == caster)
            return;

        if(!targets.ContainsKey(col.gameObject))
        {
            if (col.gameObject.GetComponent<Attack>())
            {
                float change = col.gameObject.GetComponent<Attack>().actualAttackSpeed * baseValue;
                col.gameObject.GetComponent<Attack>().actualAttackSpeed -= change;
                targets.Add(col.gameObject, change);
            }
        }
    }
    //Find in dictionary, give back speed and remove
    void OnTriggerExit(Collider col)
    {
        if (targets.ContainsKey(col.gameObject))
        {
            foreach(KeyValuePair<GameObject,float> item in targets)
            {
                if(item.Key == col.gameObject)
                {
                    col.gameObject.GetComponent<Attack>().actualAttackSpeed += item.Value;
                    break;
                }
            }
        }
    }
    //Back all values to their owners when die
    void OnDestroy()
    {
        foreach (KeyValuePair<GameObject, float> item in targets)
        {
            GameObject x = item.Key;
            if(x != null)
                x.GetComponent<Attack>().actualAttackSpeed += item.Value;
        }
    }
}
