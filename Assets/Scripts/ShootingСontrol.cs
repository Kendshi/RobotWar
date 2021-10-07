using UnityEngine;
using Cinemachine;
using System.Collections;

public class ShootingСontrol : MonoBehaviour
{
    [SerializeField] private Transform _startPositonForProjectile;
    [SerializeField] private CinemachineImpulseSource _impulse;
    [SerializeField] private float _delayTimeBetweenShoots;
    [SerializeField] private StartShootEffectPool _effectPoolPrefab;
    [SerializeField] private ProjectilePool _projectilePool;
    [SerializeField] private CollisionEffectPool _collisionEffectPool;
    private bool _canNotShoot;
    private Transform _tower;

    private void Start()
    {
        _tower = GetComponentInChildren<TowerRotate>().transform;
        _effectPoolPrefab = _effectPoolPrefab.CreatePool(_tower, _startPositonForProjectile);
        _projectilePool = _projectilePool.CreatePool(_tower, _startPositonForProjectile);
        _collisionEffectPool = _collisionEffectPool.CreatePool();
        InputListener.Fire += Fire;
    }

    public void Fire()
    {
        if (!_canNotShoot)
        {
            _canNotShoot = true;
            _projectilePool.ActivatePoolElement();
            _impulse.GenerateImpulse();
            _effectPoolPrefab.ActivatePoolElement();
            StartCoroutine(DelayBetweenShots(_delayTimeBetweenShoots));
        }
    }

    private IEnumerator DelayBetweenShots(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        _canNotShoot = false;
    }

    private void OnDestroy()
    {
        InputListener.Fire -= Fire;
    }
}
