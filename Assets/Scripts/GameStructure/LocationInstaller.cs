using Zenject;
using UnityEngine;

public class LocationInstaller : MonoInstaller
{
    [SerializeField] private Transform _startPoint;
    [SerializeField] private GameObject _playerPrefab;
    [SerializeField] private InputListener _inputListener;
    [SerializeField] private EnemyFactory _enemyFactory;

    public override void InstallBindings()
    {
        BindInput();
        BindPlayerRobot();
        BindEnemyFactory();
    }

    private void BindEnemyFactory()
    {
        Container.Bind<EnemyFactory>().FromInstance(_enemyFactory).AsSingle();
    }
    
    private void BindInput()
    {
        Container.Bind<InputListener>().FromInstance(_inputListener).AsSingle();
    }

    private void BindPlayerRobot()
    {
        PlayerMovement movementController = Container
                    .InstantiatePrefabForComponent<PlayerMovement>(_playerPrefab, _startPoint.position, Quaternion.identity, null);

        Container.Bind<PlayerMovement>().FromInstance(movementController).AsSingle();
    }
}
