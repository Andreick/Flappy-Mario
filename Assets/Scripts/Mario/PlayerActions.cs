using UnityEngine;

[RequireComponent(typeof(PlayerEvents))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerActions : MonoBehaviour
{
    [SerializeField] ReadOnlyVector2Variable flyForce;

    private PlayerEvents playerEvents;
    private Rigidbody2D rigidbd2D;

    private void Awake()
    {
        rigidbd2D = GetComponent<Rigidbody2D>();
        playerEvents = GetComponent<PlayerEvents>();
    }

    private void OnEnable()
    {
        playerEvents.OnPlayerFire += Fly;
        playerEvents.OnPlayerLose += Die;
    }

    private void OnDisable()
    {
        playerEvents.OnPlayerFire -= Fly;
        playerEvents.OnPlayerLose -= Die;
    }

    private void Fly()
    {
        rigidbd2D.velocity = Vector2.zero;
        rigidbd2D.AddForce(flyForce.Value);
    }

    private void Die()
    {
        rigidbd2D.velocity = Vector2.zero;
        GameObject.Destroy(this);
    }
}
