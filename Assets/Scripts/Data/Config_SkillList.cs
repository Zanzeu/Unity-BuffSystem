using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Config_SkillList
{
    public static Config_SkillList instance = new Config_SkillList();

    public Dictionary<string, SkillBase> skillList;

    public void Init()
    {
        skillList = new Dictionary<string, SkillBase>();

        SkillBase[] list = Resources.LoadAll<SkillBase>("SO/Skill");

        foreach (SkillBase skill in list)
        {
            skillList.Add(skill.id, skill);
        }
    }
}
