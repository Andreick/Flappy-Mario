using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ScrollingGround : MonoBehaviour
{
    [SerializeField] private ReadOnlyVector2Variable scrollingVelocity;
    [SerializeField] private ActionGameEvent OnPlayerLose;

    private Rigidbody2D rigidbd2D;
    private Vector2 startPosition;

    private void Awake()
    {
        rigidbd2D = GetComponent<Rigidbody2D>();
        startPosition = transform.position;
    }

    private void OnEnable()
    {
        rigidbd2D.velocity = scrollingVelocity.Value;
        OnPlayerLose.Subscribe(Stop);
    }

    private void OnDisable()
    {
        OnPlayerLose.Unsubscribe(Stop);
        rigidbd2D.velocity = Vector2.zero;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        transform.position = startPosition;
    }

    private void Stop()
    {
        Debug.Log("stop ground");
        enabled = false;
    }
}
