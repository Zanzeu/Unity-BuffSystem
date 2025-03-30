using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Skill/三连击", fileName = "Skill_thirdCombo")]
public class Skill_thirdCombo : SkillBase
{
    public override void OnApply()
    {
        GlobalSkillEventBus.Subscribe<ComboSkillEvent>(Combo);
        Debug.Log("添加三连击技能");
    }

    public override void OnExpire()
    {
        GlobalSkillEventBus.Unsubscribe<ComboSkillEvent>(Combo);
        Debug.Log("移除三连击技能");
    }

    private void Combo(SkillEvent eventData)
    {
        if (eventData.Tags.TryGetValue("IsValid", out var isValid) && (bool)isValid)
        {
            Debug.Log("触发三连击!");
        }
    }
}
