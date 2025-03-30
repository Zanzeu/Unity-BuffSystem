using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    protected override void Awake()
    {
        base.Awake();
        Config_BuffList.instance.Init();
        Config_SkillList.instance.Init();
    }
}
