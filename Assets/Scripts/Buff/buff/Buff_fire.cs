using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(menuName = "SO/Buff/����", fileName = "Buff_fire")]
public class Buff_fire : BuffBase, IBuffApply, IBuffReset, IBuffExpire
{
    public void OnApply(BuffManager target)
    {
        Debug.Log($"����!{curStacks}");
    }

    public void OnExpire(BuffManager target)
    {
        Debug.Log("�Ƴ�����");
    }

    public void OnReset(BuffManager target)
    {
        OnExpire(target);
        OnApply(target);

        GlobalSkillEventBus.Invoke(GlobalSkillEventBus.TiggerSkill<FireSkillEvent>(
            EventType.StackFull, 
            target, 
            this,
            id,
            new Dictionary<string, object>()
            {
                ["IsValid"] = curStacks == applyStacks
            }));
    }
}