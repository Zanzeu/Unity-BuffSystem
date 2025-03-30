using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum EventType
{
    StackFull,
    ChangeStack,
    ChangeDuration,
    AttackCombo,
}

public class GlobalSkillEventBus : MonoBehaviour
{
    private static Dictionary<Type, Delegate> _eventHandlers = new Dictionary<Type, Delegate>();

    public static void Subscribe<T>(Action<T> handler)
    {
        if (_eventHandlers.TryGetValue(typeof(T), out var existing))
        {
            _eventHandlers[typeof(T)] = Delegate.Combine(existing, handler);
        }
        else
        {
            _eventHandlers[typeof(T)] = handler;
        }
    }

    public static void Unsubscribe<T>(Action<T> handler)
    {
        if (_eventHandlers.TryGetValue(typeof(T), out var existing))
        {
            _eventHandlers[typeof(T)] = Delegate.Remove(existing, handler);
        }
    }

    public static void Invoke<T>(T eventData) where T : SkillEvent
    {
        if (_eventHandlers.TryGetValue(typeof(T), out var handler))
        {
            (handler as Action<T>)?.Invoke(eventData);
        }
    }

    public static T TiggerSkill<T>(EventType type, BuffManager target, BuffBase buff, string id) where T : SkillEvent, new()
    {
        return new T()
        {
            Target = target,
            Buff = buff,
            EventType = type,
            SourceBuffID = id,
            TargetTag = target.tag
        };
    }

    public static T TiggerSkill<T>(EventType type, BuffManager target, BuffBase buff, string id, Dictionary<string, object> tags) where T : SkillEvent, new()
    {
        return new T()
        {
            Target = target,
            Buff = buff,
            EventType = type,
            SourceBuffID = id,
            TargetTag = target.tag,
            Tags = tags ?? new Dictionary<string, object>()
        };
    }

    public static T TriggerSkill<T>(EventType type, Dictionary<string, object> tags) where T : SkillEvent, new()
    {
        return new T()
        {
            EventType = type,
            Tags = tags ?? new Dictionary<string, object>()
        };
    }
}