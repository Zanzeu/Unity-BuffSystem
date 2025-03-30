using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class BuffManager : SerializedMonoBehaviour
{
    private Dictionary<string, BuffBase> _buffs;
    private List<BuffBase> _endBuffCache;
    private CharacterAttributesBase _characterAttributes;

    private void Awake()
    {
        _characterAttributes = GetComponent<CharacterAttributesBase>();
        _buffs = new Dictionary<string, BuffBase>();
        _endBuffCache = new List<BuffBase>();
    }

    private void Update()
    {
        UpdateBuff();

        if (Input.GetKeyDown(KeyCode.Q))
        {
            ApplyBuff(Instantiate(Config_BuffList.instance.buffList["ice"]));
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            ApplyBuff(Instantiate(Config_BuffList.instance.buffList["fire"]));
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            ApplyBuff(Instantiate(Config_BuffList.instance.buffList["speed"]));
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            ApplyBuff(Instantiate(Config_BuffList.instance.buffList["speedStrength"]));
        }
    }

    public void ApplyBuff(BuffBase buff)
    {
        if (_buffs.TryGetValue(buff.id, out BuffBase existingBuff))
        {
            existingBuff.ResetBuff();

            if (existingBuff is IBuffReset resetBuff)
            {   
                resetBuff.OnReset(this);
            }   

            if (existingBuff is IForgeReset resetForge)
            {
                resetForge.OnReset(_characterAttributes);
            }
        }
        else
        {
            _buffs.Add(buff.id, buff);
            buff.Init();
            if (buff is IBuffApply applyBuff)
            {
                applyBuff.OnApply(this);
            }

            if (buff is IForgeApply applyForge)
            {
                applyForge.OnApply(_characterAttributes);
            }
        }
    }

    private void UpdateBuff()
    {
        _endBuffCache.Clear();

        foreach (BuffBase buff in _buffs.Values)
        {
            if (buff is IBuffUpdate updateBuff)
            {
                updateBuff.OnUpdate(this);
            }

            if (buff is IForgeUpdate updateForge)
            {
                updateForge.OnUpdate(_characterAttributes);
            }

            if (buff.Timer())
            {
                if (buff is IBuffExpire expireBuff)
                {
                    expireBuff.OnExpire(this);
                }

                if (buff is IForgeExpire expireForge)
                {
                    expireForge.OnExpire(_characterAttributes);  
                }

                _endBuffCache.Add(buff);
            }
        }

        foreach (BuffBase buff in _endBuffCache)
        {
            RemoveBuff(buff);
        }
    }

    private void RemoveBuff(BuffBase buff)
    {
        _buffs.Remove(buff.id);
    }
}
