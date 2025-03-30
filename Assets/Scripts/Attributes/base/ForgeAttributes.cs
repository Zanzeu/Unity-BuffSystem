using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ForgeAttributes
{
    public float baseVal;
    public float applyVal;
    public List<ForgeAttributesBuff> modifiers;
    public bool isDirty;

    public ForgeAttributes(float baseVal)
    {
        this.baseVal = baseVal;
        applyVal = baseVal;
        modifiers = new List<ForgeAttributesBuff>();
        isDirty = false;
    }

    public void IncreaseBaseValue(float val)
    {
        baseVal += val;
        isDirty = true;
    }

    public void DecreaseBaseValue(float val)
    {
        baseVal -= val;
        isDirty = true;
    }

    public void OnAttributesUpdate()
    {
        if (!isDirty)
        {
            return;
        }

        applyVal = Mathf.Max(0f, ForgeModifier.CalculateApplyValue(this));

        isDirty = false;
    }
}
