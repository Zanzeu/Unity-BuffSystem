using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Buff/�ٶ�", fileName = "Buff_speed")]
public class Buff_speed : BuffBase, IForgeApply,IForgeExpire
{
    public void OnApply(CharacterAttributesBase target)
    {
        var modifier = new ForgeAttributesBuff
        {
            SourceBuff = this,
            Priority = ForgePriority.High,
            IsPercentage = false,
            Value = 5f
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
