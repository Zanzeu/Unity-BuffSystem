using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Skill/冰冻持续时间增加", fileName = "Skill_addIceDuration")]
public class Skill_addIceDuration : SkillBase
{
    public override void OnApply()
    {
        GlobalSkillEventBus.Subscribe<IceSkillEvent>(SetDuration);
        Debug.Log("增加冰冻持续时间!");
    }

    public override void OnExpire()
    {
        GlobalSkillEventBus.Unsubscribe<IceSkillEvent>(SetDuration);
        Debug.Log("减少冰冻持续时间");
    }

    private void SetDuration(SkillEvent eventData)
    {
        if (eventData.TargetTag != "Player" && eventData.EventType == EventType.ChangeDuration && eventData.SourceBuffID == "ice")
        {
            eventData.Buff.applyDuration = 10f;
        }
    }
}