public class AttackSpeedAuraSkill : BaseAuraSkill
{
    public void Start()
    {
        valueChange = caster.GetComponent<Attack>().actualAttackSpeed * baseValue * level;
        caster.GetComponent<Attack>().actualAttackSpeed += valueChange;
    }

    void OnDestroy()
    {
        caster.GetComponent<Attack>().actualAttackSpeed -= valueChange;
    }
}
