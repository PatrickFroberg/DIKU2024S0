using UnityEngine;
using CreatorKitCode;

public class MaEffect : UsableItem.UsageEffect
{
    public float Duration = 10.0f;
    public int StatChange = 50;
    public Sprite EffectSprite;

    public override bool Use(CharacterData user)
    {
        StatSystem.StatModifier modifier = new StatSystem.StatModifier();
        modifier.ModifierMode = StatSystem.StatModifier.Mode.Absolute;
        modifier.Stats.agility = StatChange;

        VFXManager.PlayVFX(VFXType.Stronger, user.transform.position);

        user.Stats.AddTimedModifier(modifier, Duration, "AgilityAdd", EffectSprite);

        return true;
    }
}
