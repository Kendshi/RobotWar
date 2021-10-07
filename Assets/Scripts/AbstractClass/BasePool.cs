using UnityEngine;

public abstract class BasePool<T> : MonoBehaviour
{
    [SerializeField] protected int _poolCount = 3;
    [SerializeField] protected bool _autoExpand = false;
    [SerializeField] protected T _poolObject;
    protected Transform _startPosition;
    protected Transform _rotate;

    public virtual void ActivatePoolElement()
    {

    }
}
