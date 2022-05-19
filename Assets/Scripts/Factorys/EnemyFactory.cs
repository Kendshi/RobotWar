using UnityEngine;
using Zenject;

public class EnemyFactory : MonoBehaviour
{
    [SerializeField] private EnemyConfig _smallRobot, _tank;
    [Inject] private DiContainer _diContainer;

    public Enemy Get(EnemyType type)
    {
        var config = GetConfig(type);
        Enemy instance = CreateGameObjectInstance(config.Prefab);
        return instance;
    }

    private EnemyConfig GetConfig(EnemyType type)
    {
        switch (type)
        {
            case EnemyType.Speed:
                return _smallRobot;
            case EnemyType.Slow:
                return _tank;
            default:
                return _smallRobot;
        }
    }

    private Enemy CreateGameObjectInstance(Enemy prefab)
    {
        Enemy instance = _diContainer.InstantiatePrefab(prefab).GetComponent<Enemy>();
        return instance;
    }


}
