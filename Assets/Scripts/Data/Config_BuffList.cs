using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Config_BuffList
{
    public static Config_BuffList instance = new Config_BuffList();

    public Dictionary<string, BuffBase> buffList;

    public void Init()
    {   
        buffList = new Dictionary<string, BuffBase>();

       BuffBase[] list = Resources.LoadAll<BuffBase>("SO/Buff");

        foreach (BuffBase buff in list)
        {
            buffList.Add(buff.id, buff);
        }
    }
}
