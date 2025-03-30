using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Skill/��������ʱ������", fileName = "Skill_addIceDuration")]
public class Skill_addIceDuration : SkillBase
{
    public override void OnApply()
    {
        GlobalSkillEventBus.Subscribe<IceSkillEvent>(SetDuration);
        Debug.Log("���ӱ�������ʱ��!");
    }

    public override void OnExpire()
    {
        GlobalSkillEventBus.Unsubscribe<IceSkillEvent>(SetDuration);
        Debug.Log("���ٱ�������ʱ��");
    }

    private void SetDuration(SkillEvent eventData)
    {
        if (eventData.TargetTag != "Player" && eventData.EventType == EventType.ChangeDuration && eventData.SourceBuffID == "ice")
        {
            eventData.Buff.applyDuration = 10f;
        }
    }
}