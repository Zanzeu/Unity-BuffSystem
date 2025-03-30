using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Skill/������������", fileName = "Skill_addIceStack")]
public class Skill_addIceStack : SkillBase
{
    public override void OnApply()
    {
        GlobalSkillEventBus.Subscribe<IceSkillEvent>(SetStack);
        Debug.Log("���ӱ�������!");
    }

    public override void OnExpire()
    {
        GlobalSkillEventBus.Unsubscribe<IceSkillEvent>(SetStack);
        Debug.Log("���ٱ�������");
    }

    private void SetStack(SkillEvent eventData)
    {
        if (eventData.TargetTag != "Player" && eventData.EventType == EventType.ChangeStack && eventData.SourceBuffID == "ice")
        {
            eventData.Buff.applyStacks = 10;
        }
    }
}