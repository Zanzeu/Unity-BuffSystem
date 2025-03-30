using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(menuName = "SO/Skill/冻结", fileName = "Skill_frozen")]
public class Skill_frozen : SkillBase
{
    public override void OnApply()
    {
        GlobalSkillEventBus.Subscribe<IceSkillEvent>(Frozen);
        Debug.Log("添加冻结技能");
    }

    public override void OnExpire()
    {
        GlobalSkillEventBus.Unsubscribe<IceSkillEvent>(Frozen);
        Debug.Log("移除冻结技能");
    }

    private void Frozen(SkillEvent eventData)
    {   
        if (eventData.TargetTag != "Player" && eventData.Tags.TryGetValue("IsValid", out var isValid) && (bool)isValid && eventData.EventType == EventType.StackFull && eventData.SourceBuffID =="ice") 
        {
            eventData.Target.ApplyBuff(Config_BuffList.instance.buffList["frozen"]);
            eventData.Buff.End();
        }
    }
}
