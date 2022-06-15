using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "EnemysWaveInfo", menuName = "Info/EnemyWaves")]
public class EnemysWaveInfo : ScriptableObject
{
    public EnemyType[] Wave1;
    public EnemyType[] Wave2;
    public EnemyType[] Wave3;
    public EnemyType[] Wave4;
    public EnemyType[] Wave5;
    public EnemyType[] Wave6;
    public EnemyType[] Wave7;
    public EnemyType[] Wave8;
    public EnemyType[] Wave9;
    public EnemyType[] Wave10;

    public EnemyType[][] AllWave = new EnemyType[10][];

    public void Init()
    {
        AllWave[0] = Wave1;
        AllWave[1] = Wave2;
        AllWave[2] = Wave3;
        AllWave[3] = Wave4;
        AllWave[4] = Wave5;
        AllWave[5] = Wave6;
        AllWave[6] = Wave7;
        AllWave[7] = Wave8;
        AllWave[8] = Wave9;
        AllWave[9] = Wave10;
    }

}
