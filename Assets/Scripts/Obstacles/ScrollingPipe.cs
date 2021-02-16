using System.Collections;
using UnityEngine;

public class ScrollingPipe : MonoBehaviour
{
    [SerializeField] private RandomInt spawnPositionY;
    [SerializeField] private ReadOnlyVector2Variable scrollingVelocity;
    [SerializeField] private ReadOnlyIntVariable pipesInPool;
    [SerializeField] private ReadOnlyFloatVariable spawnRate;
    [SerializeField] private ActionGameEvent OnPlayerLose;

    private Rigidbody2D rigidbd2D;
    private Coroutine resetPosition;

    private void Awake()
    {
        rigidbd2D = GetComponent<Rigidbody2D>();
        gameObject.SetActive(false);
    }

    private void Start()
    {
        resetPosition = StartCoroutine(ResetPosition());
    }

    private IEnumerator ResetPosition()
    {
        OnPlayerLose.Subscribe(Stop);

        float spawnTime = spawnRate.Value * pipesInPool.Value;
        Vector2 spawnPosition = transform.position;

        rigidbd2D.velocity = scrollingVelocity.Value;

        for ( ; ; )
        {
            yield return new WaitForSeconds(spawnTime);

            spawnPosition.y = spawnPositionY.Value;
            transform.position = spawnPosition;
        }
    }

    private void Stop()
    {
        Debug.Log("stop pipe");
        StopCoroutine(resetPosition);
        rigidbd2D.velocity = Vector2.zero;

        OnPlayerLose.Unsubscribe(Stop);
    }
}
