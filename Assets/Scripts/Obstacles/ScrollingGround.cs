using UnityEngine;

public class ScrollingGround : ScrollingObstacle
{
    private Vector2 startPosition;

    protected override void Awake()
    {
        base.Awake();
        startPosition = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        transform.position = startPosition;
    }
}
