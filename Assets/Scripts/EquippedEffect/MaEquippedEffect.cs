using CreatorKitCode;

public class MaEquippedEffect : EquipmentItem.EquippedEffect
{
    public int StatChange = 50000;
    
    public override void Equipped(CharacterData user)
     {
        StatSystem.StatModifier modifier = new StatSystem.StatModifier();
        modifier.ModifierMode = StatSystem.StatModifier.Mode.Absolute;
        modifier.Stats.strength += StatChange;

        user.Stats.AddModifier(modifier);
    }
     
     public override void Removed(CharacterData user)
     {
        StatSystem.StatModifier modifier = new StatSystem.StatModifier();
        modifier.ModifierMode = StatSystem.StatModifier.Mode.Absolute;
        modifier.Stats.strength -= StatChange;

        user.Stats.AddModifier(modifier);
    }
}
