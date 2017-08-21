public class AttackAuraSkill : BaseSkill
{
    public override void Start()
    {
        base.Start();
        valueChange = caster.GetComponent<Attack>().actualDamage * baseValue;
        caster.GetComponent<Attack>().actualDamage += valueChange;
    }

    void OnDestroy()
    {
        caster.GetComponent<Attack>().actualDamage -= valueChange;
    }
}
