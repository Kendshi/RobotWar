
using UnityEngine;

public abstract class BaseFactory<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] private T _prefab;
    [SerializeField] private Transform _spawnPosition;

    public T CreateNewObject()
    {
        return Instantiate(_prefab, _spawnPosition.position, Quaternion.identity);
    }
}
