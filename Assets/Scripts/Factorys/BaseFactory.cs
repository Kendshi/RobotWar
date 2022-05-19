using UnityEngine;

public abstract class BaseFactory<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] private T _prefab;
    [SerializeField] private Transform _spawnPosition;

    private T CreateGameObjectInstance(T prefab)
    {
        T instance = Instantiate(prefab);
        return instance;
    }
}
