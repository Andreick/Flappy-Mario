using System;
using UnityEngine;

public class PlayerEvents : MonoBehaviour
{
    public event Action OnPlayerFire;
    public event Action OnPlayerLose;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            OnPlayerFire?.Invoke();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        OnPlayerLose?.Invoke();
        GameObject.Destroy(this);
    }
}
