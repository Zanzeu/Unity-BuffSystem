using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Skill/冰冻层数增加", fileName = "Skill_addIceStack")]
public class Skill_addIceStack : SkillBase
{
    public override void OnApply()
    {
        GlobalSkillEventBus.Subscribe<IceSkillEvent>(SetStack);
        Debug.Log("增加冰冻层数!");
    }

    public override void OnExpire()
    {
        GlobalSkillEventBus.Unsubscribe<IceSkillEvent>(SetStack);
        Debug.Log("减少冰冻层数");
    }

    private void SetStack(SkillEvent eventData)
    {
        if (eventData.TargetTag != "Player" && eventData.EventType == EventType.ChangeStack && eventData.SourceBuffID == "ice")
        {
            eventData.Buff.applyStacks = 10;
        }
    }
}