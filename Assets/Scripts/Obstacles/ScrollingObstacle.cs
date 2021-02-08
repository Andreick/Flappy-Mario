using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public abstract class ScrollingObstacle : MonoBehaviour
{
    [SerializeField] ReadOnlyVector2Variable scrollingVelocity;

    private Rigidbody2D rigidbd2D;

    protected virtual void Awake()
    {
        rigidbd2D = GetComponent<Rigidbody2D>();
    }

    protected virtual void OnEnable()
    {
        rigidbd2D.velocity = scrollingVelocity.Value;
    }

    protected virtual void OnDisable()
    {
        rigidbd2D.velocity = Vector2.zero;
    }
}
