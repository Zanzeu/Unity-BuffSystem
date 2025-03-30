using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ForgeModifier
{
    public static float CalculateApplyValue(ForgeAttributes forge)
    {
        float finalVal = forge.baseVal;
        float additiveSum = 0f;
        float multiplicativeProduct = 1f;

        forge.modifiers.Sort(ModifierPrioritySort);

        foreach (var modifier in forge.modifiers)
        {
            if (modifier.IsPercentage)
            {
                multiplicativeProduct += modifier.Value;
            }
            else
            {
                additiveSum += modifier.Value;
            }
        }

        float result = (finalVal + additiveSum) * multiplicativeProduct;

        result = Mathf.Max(result, 0f);

        return result;
    }

    public static void AddModifier(ForgeAttributesBuff modifier, ForgeAttributes forge)
    {
        forge.modifiers.Add(modifier);
        forge.isDirty = true;
    }

    public static void RemoveModifier(BuffBase buff, ForgeAttributes forge)
    {
        forge.modifiers.RemoveAll(mod => mod.SourceBuff == buff);
        forge.isDirty = true;
    }

    public static void IncreaseBaseValue(ForgeAttributes forge, float val)
    {
        forge.IncreaseBaseValue(val);
    }

    public static void DecreaseBaseValue(ForgeAttributes forge, float val)
    {
        forge.DecreaseBaseValue(val);
    }

    private static int ModifierPrioritySort(ForgeAttributesBuff a, ForgeAttributesBuff b)
    {
        return a.Priority <= b.Priority ? 1 : -1;
    }
}

public struct ForgeAttributesBuff
{
    public BuffBase SourceBuff;
    public ForgePriority Priority;
    public bool IsPercentage;
    public float Value;
}

public enum ForgePriority
{
    Low = 100,
    Middle = 500,
    High = 1000,
}