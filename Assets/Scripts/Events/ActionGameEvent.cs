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

    public void Subscribe(Action subscriber)
    {
        actionEvent += subscriber;
    }

    public void Unsubscribe(Action subscriber)
    {
        actionEvent -= subscriber;
    }
}
