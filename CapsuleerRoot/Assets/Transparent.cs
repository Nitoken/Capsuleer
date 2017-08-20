using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transparent : MonoBehaviour
{
    public Shader transparentShader;
    public float transparentValue;
    Dictionary<Material, Shader> shadersInMats;

    bool isHitted = false;
    public bool IsHitted
    {
        get
        {
            return isHitted;
        }
        set
        {
            if (isHitted != value)
            {
                isHitted = value;
                ChangeStatement(isHitted);
            }
        }
    }

    void Start()
    {
        Material[] mats = GetComponent<Renderer>().materials;
        shadersInMats = new Dictionary<Material, Shader>();
        for (int i = 0; i < mats.Length; i++)
        {
            shadersInMats.Add(mats[i], mats[i].shader);
        }
    }

    void ChangeStatement(bool status)
    {
        if (status)
            MakeTransparent();
        else
            MakeNormal();
    }

    void MakeTransparent()
    {
        Material[] mats = GetComponent<Renderer>().materials;
        for (int i = 0; i < mats.Length; i++)
        {
            mats[i].shader = transparentShader;
            mats[i].color = new Color(1, 1, 1, transparentValue);
        }
    }

    void MakeNormal()
    {
        Material[] mats = GetComponent<Renderer>().materials;
        for (int i = 0; i < mats.Length; i++)
        {
            foreach(KeyValuePair<Material,Shader> item in shadersInMats)
            {
                if (item.Key == mats[i])
                {
                    mats[i].shader = item.Value;
                    mats[i].color = new Color(1, 1, 1, 1);
                }
            }
        }
    }
}
