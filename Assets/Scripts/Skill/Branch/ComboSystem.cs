using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboSystem : MonoBehaviour
{
    private int _currentCombo;
    private float _lastHitTime = 0f;
    private float _comboWindow = 2f;

    private void Update()
    {
        if (_lastHitTime >= _comboWindow)
        {
            _currentCombo = 0;
        }

        _lastHitTime += Time.deltaTime;
    }

    public void RecordCombo()
    {
        _lastHitTime = 0f;
        _currentCombo++;

        GlobalSkillEventBus.Invoke(GlobalSkillEventBus.TriggerSkill<ComboSkillEvent>(
            EventType.AttackCombo,
            new Dictionary<string, object>
            {
                ["ComboCount"] = _currentCombo,
                ["IsValid"] = (_currentCombo % 3) == 0
            }));
    }
}
