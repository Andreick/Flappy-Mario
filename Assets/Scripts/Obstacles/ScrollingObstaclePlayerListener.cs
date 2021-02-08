using UnityEngine;

[RequireComponent(typeof(ScrollingObstacle))]
public class ScrollingObstaclePlayerListener : MonoBehaviour
{
    private ScrollingObstacle scrollingObstacle;
    private PlayerEvents playerEvents;

    private void Awake()
    {
        scrollingObstacle = GetComponent<ScrollingObstacle>();
        playerEvents = GameObject.FindGameObjectWithTag("Mario").GetComponent<PlayerEvents>();
    }

    private void OnEnable()
    {
        playerEvents.OnPlayerLose += Stop;
    }

    private void OnDisable()
    {
        playerEvents.OnPlayerLose -= Stop;
    }

    private void Stop()
    {
        scrollingObstacle.enabled = false;
    }
}
