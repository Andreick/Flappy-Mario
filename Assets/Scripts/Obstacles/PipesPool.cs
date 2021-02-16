using System.Collections;
using UnityEngine;

public class PipesPool : MonoBehaviour
{
    [SerializeField] private GameObject pipesPrefab;
    [SerializeField] private ReadOnlyIntVariable pipesInPool;
    [SerializeField] private ReadOnlyFloatVariable spawnPositionX;
    [SerializeField] private RandomInt spawnPositionY;
    [SerializeField] private ReadOnlyFloatVariable spawnDelay;
    [SerializeField] private ReadOnlyFloatVariable spawnRate;
    [SerializeField] private ActionGameEvent OnPlayerLose;

    private GameObject[] pipes;
    private Coroutine setPipes;

    private void Awake()
    {
        pipes = new GameObject[pipesInPool.Value];

        Vector2 spawnPosition = new Vector2(spawnPositionX.Value, 0);

        for (int i = 0; i < pipes.Length; i++)
        {
            spawnPosition.y = spawnPositionY.Value;
            pipes[i] = Instantiate(pipesPrefab, spawnPosition, Quaternion.identity, transform);
        }

        setPipes = StartCoroutine(SetPipes());
    }

    private IEnumerator SetPipes()
    {
        OnPlayerLose.Subscribe(Stop);

        yield return new WaitForSeconds(spawnDelay.Value);

        pipes[0].SetActive(true);

        for (int i = 1; i < pipes.Length; i++)
        {
            yield return new WaitForSeconds(spawnRate.Value);

            pipes[i].SetActive(true);
        }

        OnPlayerLose.Unsubscribe(Stop);
    }

    private void Stop()
    {
        Debug.Log("stop pipe spawn");
        StopCoroutine(setPipes);
    }
}
