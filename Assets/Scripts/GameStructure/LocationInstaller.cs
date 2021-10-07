using Zenject;
using UnityEngine;

public class LocationInstaller : MonoInstaller
{
    [SerializeField] private Transform StartPoint;
    [SerializeField] private GameObject PlayerPrefab;
    [SerializeField] private InputListener InputListener;

    public override void InstallBindings()
    {
        BindInstallerInterface();
        BindInput();
        BindPlayerRobot();
    }

    private void BindInstallerInterface()
    {
        Container.BindInterfacesTo<LocationInstaller>().FromInstance(this).AsSingle();
    }

    private void BindInput()
    {
        Container.Bind<InputListener>().FromInstance(InputListener).AsSingle();
    }

    private void BindPlayerRobot()
    {
        MovementController movementController = Container
                    .InstantiatePrefabForComponent<MovementController>(PlayerPrefab, StartPoint.position, Quaternion.identity, null);

        Container.Bind<MovementController>().FromInstance(movementController).AsSingle();
    }
}
