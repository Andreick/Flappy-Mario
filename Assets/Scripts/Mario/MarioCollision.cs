using UnityEngine;

public class MarioCollision : MonoBehaviour
{
    [SerializeField] private ActionGameEvent PlayerLose;

    private void Start()
    {
        if (!enabled) Destroy(this);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("player collision");
        PlayerLose.Trigger();
        Destroy(this);
    }
}
