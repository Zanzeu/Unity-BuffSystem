using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CharacterAttributesBase : MonoBehaviour
{   
    [SerializeField] private float baseMaxHP;
    [SerializeField] private float baseSPD;
    [SerializeField] private float baseATK;
    [SerializeField] private float baseDEF;

    private bool _globalDirtyMark;

    public Action onAttributeUpdate;
    public Action onAttributeUpdateFinish;

    public ForgeAttributes forgeMaxHP { get; set; }
    public ForgeAttributes forgeCurHP { get; set; }
    public ForgeAttributes forgeATK { get; set; }
    public ForgeAttributes forgeSPD { get; set; }
    public ForgeAttributes forgeDEF { get; set; }

    public float MaxHP => forgeMaxHP.applyVal;
    public float SPD => forgeSPD.applyVal;
    public float ATK => forgeATK.applyVal;
    public float DEF => forgeDEF.applyVal;
    public float CurHP
    {
        set => forgeCurHP.baseVal = value;
        get
        {
            return forgeCurHP.baseVal;
        }
    }

    [Space(10)]
    [Header("≤‚ ‘µƒÀŸ∂»")]
    public float spd;

    private void Awake()
    {
        ForgeInit();
    }

    private void LateUpdate()
    {   
        if (!_globalDirtyMark)
        {
            return;
        }

        onAttributeUpdate?.Invoke();
        onAttributeUpdateFinish?.Invoke();
        _globalDirtyMark = false;    
    }

    private void FixedUpdate()
    {
        spd = SPD;
    }

    private void ForgeInit()
    {
        forgeMaxHP = new ForgeAttributes(baseMaxHP);
        forgeCurHP = new ForgeAttributes(baseMaxHP);
        forgeSPD = new ForgeAttributes(baseSPD);
        forgeATK = new ForgeAttributes(baseATK);
        forgeDEF = new ForgeAttributes(baseDEF);
    }

    private void OnEnable()
    {
        AddForgeAttriEvent();
    }

    private void OnDisable()
    {
        RemoveForgeAttriEvent();
    }

    public void AddModifier(ForgeAttributesBuff modifier, ForgeAttributes forge)
    {
        ForgeModifier.AddModifier(modifier, forge);
        _globalDirtyMark = true;
    }

    public void RemoveModifier(BuffBase buff, ForgeAttributes forge)
    {
        ForgeModifier.RemoveModifier(buff, forge);
        _globalDirtyMark = true;
    }

    public void IncreaseBaseValue(ForgeAttributes forge, float val)
    {
        ForgeModifier.IncreaseBaseValue(forge, val);
        _globalDirtyMark = true;
    }

    public void DecreaseBaseValue(ForgeAttributes forge, float val)
    {
        ForgeModifier.DecreaseBaseValue(forge, val);
        _globalDirtyMark = true;
    }

    private void AddForgeAttriEvent()
    {
        onAttributeUpdate += forgeMaxHP.OnAttributesUpdate;
        onAttributeUpdate += forgeSPD.OnAttributesUpdate;
        onAttributeUpdate += forgeATK.OnAttributesUpdate;
        onAttributeUpdate += forgeDEF.OnAttributesUpdate;
    }

    private void RemoveForgeAttriEvent()
    {
        onAttributeUpdate -= forgeMaxHP.OnAttributesUpdate;
        onAttributeUpdate -= forgeSPD.OnAttributesUpdate;
        onAttributeUpdate -= forgeATK.OnAttributesUpdate;
        onAttributeUpdate -= forgeDEF.OnAttributesUpdate;
    }
}
