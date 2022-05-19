using UnityEngine;

[CreateAssetMenu(fileName = "EnemyConfig", menuName = "Configs/new EnemyConfig")]
public class EnemyConfig : ScriptableObject
{
    [SerializeField] private Enemy _prefab;
    public Enemy Prefab => this._prefab;
}
