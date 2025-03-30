using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(menuName = "SO/Buff/����", fileName = "Buff_ice")]
public class Buff_ice : BuffBase, IBuffApply, IBuffReset, IBuffExpire
{   
    public void OnApply(BuffManager target)
    {   
        //����������
        GlobalSkillEventBus.Invoke(GlobalSkillEventBus.TiggerSkill<IceSkillEvent>(
                EventType.ChangeStack,
                target,
                this,
                id));


        //���ó���ʱ��
        GlobalSkillEventBus.Invoke(GlobalSkillEventBus.TiggerSkill<IceSkillEvent>(
                EventType.ChangeDuration,
                target,
                this,
                id));

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

        //��������������
        GlobalSkillEventBus.Invoke(GlobalSkillEventBus.TiggerSkill<IceSkillEvent>(
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
