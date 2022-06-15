using UnityEngine;
using Zenject;

public class GlobalMapInstaller : MonoInstaller
{
    [SerializeField] private Player prefab;
    [SerializeField] private Selecter selecter;


    public override void InstallBindings()
    {
        BindSelecter();
        BindPlayerRobot();
    }

    private void BindSelecter()
    {
        Container.Bind<Selecter>().FromInstance(selecter).AsSingle();
    }
    
     private void BindPlayerRobot()
     {
         Player player = Container
             .InstantiatePrefabForComponent<Player>(prefab, Vector3.one, Quaternion.identity, null);
    
         Container.Bind<Player>().FromInstance(player).AsSingle();
     }
}
