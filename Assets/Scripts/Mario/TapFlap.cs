using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class TapFlap : MonoBehaviour
{
    [SerializeField] private ReadOnlyVector2Variable flapForce;
    [SerializeField] private ActionGameEvent OnPlayerTap;
    //[SerializeField] private ActionGameEvent OnPlayerLose;

    private Rigidbody2D rigidbd2D;

    private void Awake()
    {
        rigidbd2D = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        OnPlayerTap += Flap;
        //OnPlayerLose += Die;
    }

    private void OnDisable()
    {
        OnPlayerTap -= Flap;
        //OnPlayerLose -= Die;
    }

    private void Flap()
    {
        Debug.Log("flap");
        rigidbd2D.velocity = Vector2.zero;
        rigidbd2D.AddForce(flapForce.Value);
    }

    private void Die()
    {
        Debug.Log("die");
        rigidbd2D.velocity = Vector2.zero;
        this.enabled = false;
    }
}
