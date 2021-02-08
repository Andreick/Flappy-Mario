using System.Collections;
using UnityEngine;

public class PipesPool : MonoBehaviour
{
    [SerializeField] GameObject pipesPrefab;
    [SerializeField] ReadOnlyIntVariable pipesInPool;
    [SerializeField] ReadOnlyFloatVariable spawnPositionX;
    [SerializeField] RandomInt spawnPositionY;
    [SerializeField] ReadOnlyFloatVariable spawnDelay;
    [SerializeField] ReadOnlyFloatVariable spawnRate;

    private GameObject[] pipes;

    private void Awake()
    {
        pipes = new GameObject[pipesInPool.Value];

        for (int i = 0; i < pipes.Length; i++)
        {
            pipes[i] = Instantiate(pipesPrefab, new Vector2(spawnPositionX.Value, spawnPositionY.Value), Quaternion.identity, transform);
        }

        StartCoroutine(SetPipes());
    }

    private IEnumerator SetPipes()
    {
        yield return new WaitForSeconds(spawnDelay.Value);

        foreach (GameObject pipe in pipes)
        {
            pipe.SetActive(true);

            yield return new WaitForSeconds(spawnRate.Value);
        }
    }
}
