using UnityEngine;

namespace ScriptableObjectVariable
{
    public abstract class ReadOnlyVariable<T> : ScriptableObject
    {
        [SerializeField] T value;

        public T Value { get => value; }
    }
}
