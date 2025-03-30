using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SkillBase : ScriptableObject
{
    public string id;
    public int level = 1;

    public int curLevel { get; set; }

    public void Init()
    {
        curLevel = 1;
    }

    public void SetLevel(int val = 1)
    {
        if (level == 1)
        {
            return;
        }

        curLevel += val;
        curLevel = Mathf.Clamp(curLevel, 1, level);
    }

    public abstract void OnApply();

    public abstract void OnExpire();
}
