using System;
using UnityEngine;

[CreateAssetMenu(menuName = "ActionEvent")]
public sealed class ActionGameEvent : ScriptableObject
{
    private Action actionEvent;

    public void Trigger()
    {
        actionEvent?.Invoke();
    }

    public static ActionGameEvent operator +(ActionGameEvent evt, Action sub)
    {
        evt.actionEvent += sub;
        return evt;
    }

    public static ActionGameEvent operator -(ActionGameEvent evt, Action sub)
    {
        evt.actionEvent -= sub;
        return evt;
    }
}
