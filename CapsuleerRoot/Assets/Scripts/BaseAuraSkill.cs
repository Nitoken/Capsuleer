using UnityEngine;

public class BaseAuraSkill : MonoBehaviour
{
    public GameObject caster;
    public int level = 1;
    public float baseValue, valueChange;
    public float duration = 10;

    public virtual void Start()
    {
        Destroy(gameObject, duration);
        caster = gameObject.transform.parent.gameObject;
    }
}
