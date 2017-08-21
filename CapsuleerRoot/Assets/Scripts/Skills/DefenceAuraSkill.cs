public class DefenceAuraSkill : BaseSkill
{
    public override void Start()
    {
        base.Start();
        valueChange = caster.GetComponent<Health>().actualDef * baseValue;
        caster.GetComponent<Health>().actualDef += valueChange;
    }

    void OnDestroy()
    {
        caster.GetComponent<Health>().actualDef -= valueChange;
    }
}
