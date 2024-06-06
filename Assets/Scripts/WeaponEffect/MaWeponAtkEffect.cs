using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CreatorKitCode;

public class MaWeponAtkEffect : Weapon.WeaponAttackEffect
{
    public int PercentageHealthStolen;

    public float PercentageChance;
    public int Damage;
    public float Time;

    public override void OnAttack(CharacterData target, CharacterData user, ref Weapon.AttackData attackData)
    {
        if (Random.value < (PercentageChance / 100.0f))
        {
            ElementalEffect effect = new ElementalEffect(Time, StatSystem.DamageType.Fire, Damage, 1.0f);

            target.Stats.AddElementalEffect(effect);
        }
    }
    
    public override void OnPostAttack(CharacterData target, CharacterData user, Weapon.AttackData data)
    {
        int amount = Mathf.FloorToInt(data.GetDamage(StatSystem.DamageType.Physical) * (PercentageHealthStolen / 100.0f));
        user.Stats.ChangeHealth(amount);
    }
}
