using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Buff/»º…’", fileName = "Buff_born")]
public class Buff_born : BuffBase, IBuffApply, IBuffExpire,IBuffReset
{
    public void OnApply(BuffManager target)
    {
        Debug.Log($"»º…’{curStacks}");
    }

    public void OnExpire(BuffManager target)
    {
        Debug.Log("“∆≥˝»º…’!");
    }

    public void OnReset(BuffManager target)
    {
        OnExpire(target);
        OnApply(target);
    }
}
