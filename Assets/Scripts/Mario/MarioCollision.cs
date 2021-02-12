using UnityEngine;

public class MarioCollision : MonoBehaviour
{
    [SerializeField] private ActionGameEvent PlayerLose;

    private void Awake()
    {
        if (!enabled) Destroy(this);
    }

    private void OnDisable()
    {
        Destroy(this);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collision");
        PlayerLose.Trigger();
        Destroy(this);
    }
}
