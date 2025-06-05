
using System.Text.Json;

[BuffFragment(
    "OffsetInjury",
    "受伤时有概率抵消伤害的 buff",
    Arg1 = "(float)抵消伤害概率百分比"
)]
public class Buff_OffsetInjury : BuffFragment
{
    private float _value;

    public override void InitParam(JsonElement[] args)
    {
        _value = args[0].GetSingle();
    }

    public override void OnPickUpItem()
    {
        Role.RoleState.CalcHurtDamageEvent += CalcHurtDamageEvent;
    }

    public override void OnRemoveItem()
    {
        Role.RoleState.CalcHurtDamageEvent -= CalcHurtDamageEvent;
    }

    private void CalcHurtDamageEvent(int originDamage, DamageType damageType, RefValue<int> refValue)
    {
        if (refValue.Value > 0 && Utils.Random.RandomBoolean(_value))
        {
            refValue.Value = 0;
        }
    }
}