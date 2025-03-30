using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(menuName = "SO/Buff/冰冻", fileName = "Buff_ice")]
public class Buff_ice : BuffBase, IBuffApply, IBuffReset, IBuffExpire
{   
    public void OnApply(BuffManager target)
    {   
        //设置最大层数
        GlobalSkillEventBus.Invoke(GlobalSkillEventBus.TiggerSkill<IceSkillEvent>(
                EventType.ChangeStack,
                target,
                this,
                id));


        //设置持续时间
        GlobalSkillEventBus.Invoke(GlobalSkillEventBus.TiggerSkill<IceSkillEvent>(
                EventType.ChangeDuration,
                target,
                this,
                id));

        Debug.Log($"冰冻!{curStacks}");
    }

    public void OnExpire(BuffManager target)
    {
        Debug.Log("移除冰冻");
    }

    public void OnReset(BuffManager target)
    {
        OnExpire(target);
        OnApply(target);

        //到达最大层数冻结
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
