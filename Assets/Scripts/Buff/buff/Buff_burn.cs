using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Buff/ȼ��", fileName = "Buff_born")]
public class Buff_born : BuffBase, IBuffApply, IBuffExpire,IBuffReset
{
    public void OnApply(BuffManager target)
    {
        Debug.Log($"ȼ��{curStacks}");
    }

    public void OnExpire(BuffManager target)
    {
        Debug.Log("�Ƴ�ȼ��!");
    }

    public void OnReset(BuffManager target)
    {
        OnExpire(target);
        OnApply(target);
    }
}
