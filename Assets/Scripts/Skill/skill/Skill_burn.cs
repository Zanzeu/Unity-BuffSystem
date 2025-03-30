using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Skill/ȼ��", fileName = "Skill_born")]
public class Skill_burn : SkillBase
{
    public override void OnApply()
    {
        GlobalSkillEventBus.Subscribe<FireSkillEvent>(Born);
        Debug.Log("���ȼ�ռ���");
    }

    public override void OnExpire()
    {
        GlobalSkillEventBus.Unsubscribe<FireSkillEvent>(Born);
        Debug.Log("�Ƴ�ȼ�ռ���");
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
