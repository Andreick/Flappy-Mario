using UnityEngine;

namespace ScriptableObjectModel
{
    public abstract class ReadOnlyVariable<T> : ScriptableObject
    {
        [SerializeField] T value;

        public T Value { get => value; }
    }
}
