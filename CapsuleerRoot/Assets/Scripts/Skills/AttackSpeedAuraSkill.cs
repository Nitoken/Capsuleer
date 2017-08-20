public class AttackSpeedAuraSkill : BaseAuraSkill
{
    public override void Start()
    {
        base.Start();
        valueChange = caster.GetComponent<Attack>().actualAttackSpeed * baseValue * level;
        caster.GetComponent<Attack>().actualAttackSpeed += valueChange;
    }

    void OnDestroy()
    {
        caster.GetComponent<Attack>().actualAttackSpeed -= valueChange;
    }
}
