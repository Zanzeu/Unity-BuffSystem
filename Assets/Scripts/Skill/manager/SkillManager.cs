using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    private Dictionary<string, SkillBase> _skills;

    private void Awake()
    {
        _skills = new Dictionary<string, SkillBase>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            AddSkill(Instantiate(Config_SkillList.instance.skillList["frozen"]));
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            AddSkill(Instantiate(Config_SkillList.instance.skillList["burn"]));
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            AddSkill(Instantiate(Config_SkillList.instance.skillList["addIceStack"]));
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            AddSkill(Instantiate(Config_SkillList.instance.skillList["addIceDuration"]));
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            AddSkill(Instantiate(Config_SkillList.instance.skillList["thirdCombo"]));
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            RemoveSkill(_skills["burn"]);
        }
    }

    public void AddSkill(SkillBase skill)
    {   
        if (_skills.TryGetValue(skill.id, out SkillBase s))
        {
            s.SetLevel();
        }
        else
        {
            _skills.Add(skill.id, skill);
            skill.Init();
            skill.OnApply();
        }
    }

    public void RemoveSkill(SkillBase skill)
    {   
        if (skill.curLevel == 1)
        {
            skill.OnExpire();
            _skills.Remove(skill.id);
        }
        else
        {
            skill.SetLevel(-1);
        }
    }
}
