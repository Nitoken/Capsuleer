using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transparent : MonoBehaviour
{
    [Tooltip("Choose which shader should be used. Preffer Transparent/Diffuse")]
    public Shader transparentShader;
    [Tooltip("How much alfa channel should be left")]
    public float transparentValue;
    Dictionary<Material, Shader> shadersInMats;
    Material[] mats;
    //True when hitted by Camera's raycast
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
        mats = GetComponent<Renderer>().materials; //Take used materials
        shadersInMats = new Dictionary<Material, Shader>();

        //Every material and its own shader
        for (int i = 0; i < mats.Length; i++)
            shadersInMats.Add(mats[i], mats[i].shader);
    }

    //Called when isHitted changes
    void ChangeStatement(bool status)
    {
        if (status)
            MakeTransparent();
        else
            MakeNormal();
    }

    void MakeTransparent()
    {
        //Change their shaders to transaprent
        for (int i = 0; i < mats.Length; i++)
        {
            mats[i].shader = transparentShader;
            mats[i].color = new Color(1, 1, 1, transparentValue);
        }
    }

    void MakeNormal()
    {
        //Sets normal shader to every material in object
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
