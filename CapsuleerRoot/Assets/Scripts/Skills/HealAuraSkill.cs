

public class HealAuraSkill : BaseAuraSkill
{
    public override void Start()
    {
        base.Start();
        caster.GetComponent<Health>().Heal(baseValue * level * caster.GetComponent<Health>().maxHP);
    }
}
