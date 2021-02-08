using System.Collections;
using UnityEngine;

public class ScrollingPipe : ScrollingObstacle
{
    [SerializeField] ReadOnlyFloatVariable spawnPositionX;
    [SerializeField] RandomInt spawnPositionY;
    [SerializeField] ReadOnlyFloatVariable spawnRate;
    [SerializeField] ReadOnlyIntVariable pipesInPool;

    protected override void Awake()
    {
        base.Awake();
        this.gameObject.SetActive(false);
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        StartCoroutine(ResetPosition());
    }

    private IEnumerator ResetPosition()
    {
        /*for ( ; ; )
        {
            yield return new WaitForSeconds(spawnRate.Value * pipesInPool.Value);

            transform.position = new Vector2(spawnPositionX.Value, spawnPositionY.Value);
        }*/

        yield return new WaitForSeconds(spawnRate.Value * pipesInPool.Value);

        while (this.enabled)
        {
            transform.position = new Vector2(spawnPositionX.Value, spawnPositionY.Value);

            yield return new WaitForSeconds(spawnRate.Value * pipesInPool.Value);
        }
    }
}
