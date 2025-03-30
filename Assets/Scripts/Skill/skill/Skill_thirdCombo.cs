using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Skill/������", fileName = "Skill_thirdCombo")]
public class Skill_thirdCombo : SkillBase
{
    public override void OnApply()
    {
        GlobalSkillEventBus.Subscribe<ComboSkillEvent>(Combo);
        Debug.Log("�������������");
    }

    public override void OnExpire()
    {
        GlobalSkillEventBus.Unsubscribe<ComboSkillEvent>(Combo);
        Debug.Log("�Ƴ�����������");
    }

    private void Combo(SkillEvent eventData)
    {
        if (eventData.Tags.TryGetValue("IsValid", out var isValid) && (bool)isValid)
        {
            Debug.Log("����������!");
        }
    }
}
