using UnityEngine;

[CreateAssetMenu(menuName ="Variables/RandomInt")]
public class RandomInt : ScriptableObject
{
    [SerializeField] private float min;
    [SerializeField] private float max;

    public float Value { get => Random.Range(min, max); }
}
