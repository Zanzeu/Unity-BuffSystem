using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Skill/燃烧", fileName = "Skill_born")]
public class Skill_burn : SkillBase
{
    public override void OnApply()
    {
        GlobalSkillEventBus.Subscribe<FireSkillEvent>(Born);
        Debug.Log("添加燃烧技能");
    }

    public override void OnExpire()
    {
        GlobalSkillEventBus.Unsubscribe<FireSkillEvent>(Born);
        Debug.Log("移除燃烧技能");
    }

    private void Born(SkillEvent eventData)
    {
        if (eventData.TargetTag != "Player" && eventData.Tags.TryGetValue("IsValid", out var isValid) && (bool)isValid && eventData.EventType == EventType.StackFull && eventData.SourceBuffID == "fire")
        {
            eventData.Target.ApplyBuff(Config_BuffList.instance.buffList["burn"]);
            eventData.Buff.End();
        }
    }
}
