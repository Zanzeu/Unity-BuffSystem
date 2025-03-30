using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillEvent
{
    public BuffManager Target { get; set; }
    public BuffBase Buff { get; set; }
    public EventType EventType { get; set; }
    public string TargetTag;
    public string SourceBuffID;
    public Dictionary<string, object> Tags { get; set; } = new();
}

public class IceSkillEvent : SkillEvent { }
public class FireSkillEvent : SkillEvent { }
public class ComboSkillEvent : SkillEvent { }
