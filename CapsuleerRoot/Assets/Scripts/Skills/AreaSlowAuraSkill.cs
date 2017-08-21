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
    void OnTriggerEnter(Collider col)
    {
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
