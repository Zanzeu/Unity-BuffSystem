using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(menuName = "SO/Buff/¶³½á", fileName = "Buff_frozen")]
public class Buff_frozen : BuffBase, IBuffApply, IBuffExpire
{
    public void OnApply(BuffManager target)
    {
        Debug.Log("¶³½á!");
    }

    public void OnExpire(BuffManager target)
    {
        Debug.Log("ÒÆ³ý¶³½á!");
    }
}
