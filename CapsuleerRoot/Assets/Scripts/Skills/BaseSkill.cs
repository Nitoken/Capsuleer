using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseSkill : MonoBehaviour
{
    public GameObject caster;
    public int level;
    public float baseValue, valueChange;

    public virtual void Start()
    {
        baseValue = baseValue * level;
    }
}
