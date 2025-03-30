using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Buff/�ٶ�ǿЧ", fileName = "Buff_speedStrength")]
public class Buff_speedStrength : BuffBase, IForgeApply, IForgeExpire
{
    public void OnApply(CharacterAttributesBase target)
    {
        var modifier = new ForgeAttributesBuff
        {
            SourceBuff = this,
            Priority = ForgePriority.Low,
            IsPercentage = true,
            Value = 1.0f
        };
        target.AddModifier(modifier, target.forgeSPD);

        Debug.Log("�����ٶ�!");
    }

    public void OnExpire(CharacterAttributesBase target)
    {
        target.RemoveModifier(this, target.forgeSPD);

        Debug.Log("�ٶȽ���!");
    }
}
