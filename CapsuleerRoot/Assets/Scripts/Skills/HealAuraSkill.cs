public class HealAuraSkill : BaseSkill
{
    public override  void Start()
    {
        base.Start();
        caster.GetComponent<Health>().Heal(baseValue * caster.GetComponent<Health>().maxHP);
    }
}
