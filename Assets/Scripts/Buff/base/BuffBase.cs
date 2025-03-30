using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BuffBase : ScriptableObject
{
    public string id;
    public float baseDuration = 5f;
    public int baseStacks = 1;

    public int applyStacks { get; set; }
    public float applyDuration { get; set; }

    public float curDuration { get; set; }
    public int curStacks { get; set; }

    public virtual void Init()
    {
        applyDuration = baseDuration;
        applyStacks = baseStacks;

        curDuration = 0f;
        curStacks = 1;

        SetIcon();
    }

    public bool Timer()
    {
        if (baseDuration == -1f)
        {
            return false;
        }

        curDuration += Time.deltaTime;
        if (curDuration >= applyDuration)
        {
            OnDestory();
            return true;
        }

        return false;
    }

    public void End()
    {
        curDuration = applyDuration;
    }

    public void ResetBuff(int val = 1)
    {
        ResetDuration();
        SetStacks(val);
    }

    private void ResetDuration()
    {
        if (baseDuration == -1)
        {
            return;
        }

        curDuration = 0f;
    }

    private void SetStacks(int val)
    {
        if (applyStacks == 1)
        {
            return;
        }

        curStacks += val;
        curStacks = Mathf.Clamp(curStacks, 1, applyStacks);
    }

    private void SetIcon()
    {
        Debug.Log($"…Ë÷√{id}Õº±Í");
    }

    protected virtual void OnDestory()
    {
        Debug.Log($"“∆≥˝{id}Õº±Í");
    }
}
