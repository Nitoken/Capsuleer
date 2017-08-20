public class DefenceAuraSkill : BaseAuraSkill
{
    public override void Start()
    {
        base.Start();
        valueChange = caster.GetComponent<Health>().actualDef * baseValue * level;
        caster.GetComponent<Health>().actualDef += valueChange;
    }

    void OnDestroy()
    {
        caster.GetComponent<Health>().actualDef -= valueChange;
    }
}
