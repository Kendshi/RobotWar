using UnityEngine;
using Zenject;
using System.Collections.Generic;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    private EnemyFactory _factory;
    [SerializeField] private Transform[] _spawnPosition;
    private int _spawnCount;
    private List<Enemy> _enemysOnScene = new List<Enemy>();
    [SerializeField] private EnemysWaveInfo _enemysWaveInfo;
    [SerializeField] private Queue<EnemyType> _enemysToSpawn;
    private const float _timeStep = 2;

    [Inject]
    public void Construct(EnemyFactory factory)
    {
        _factory = factory;
    }

    private void Start()
    {
        _enemysWaveInfo.Init();
        _spawnCount = 1;
        _enemysToSpawn = new Queue<EnemyType>(_enemysWaveInfo.AllWave[0]);
        StartCoroutine(DelayBetweenSpawn());
    }

    private void RemoveEnemyFromList(Enemy enemy)
    {
        enemy.EnemyDeath -= RemoveEnemyFromList;
        _enemysOnScene.Remove(enemy);
        if (_enemysOnScene.Count == 0)
        {
            _spawnCount += 1;
            FillEnemysQueue();
            StartCoroutine(DelayBetweenSpawn());
        }
    }

    private void FillEnemysQueue()
    {
        _enemysToSpawn.Clear();

        for (int i = 0; i < _enemysWaveInfo.AllWave[_spawnCount].Length; i++)
        {
            _enemysToSpawn.Enqueue(_enemysWaveInfo.AllWave[_spawnCount][i]);
        }
    }

    private IEnumerator DelayBetweenSpawn()
    {
        yield return new WaitForSeconds(_timeStep);
        if (_enemysToSpawn.Count > 0)
        {
            EnemyType currentEnemyType = _enemysToSpawn.Dequeue();
            SpawnEnemy(currentEnemyType);
            StartCoroutine(DelayBetweenSpawn());
        }
    }

    private void SpawnEnemy(EnemyType enemy)
    {
        Enemy currentEnemy = _factory.Get(enemy);
        currentEnemy.transform.position = _spawnPosition[0].position;
        _enemysOnScene.Add(currentEnemy);
        currentEnemy.EnemyDeath += RemoveEnemyFromList;
    }
}
