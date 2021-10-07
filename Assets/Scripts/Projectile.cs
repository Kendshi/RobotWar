using UnityEngine;
using System;

public class Projectile : BasePoolElement
{
    private Transform _thisTransform;
    [SerializeField] private float _speed;
    [SerializeField] private float _damageValue = 1;
    [SerializeField] private Transform _effectPoint;

    public static event Action<Transform> CollisionHappened;

    private void Update()
    {
        _thisTransform.Translate(Vector3.forward * Time.deltaTime * _speed);
    }

    private void OnEnable()
    {
        if (_thisTransform != null)
        {
            PlayElementLogic();
        }
        else
        {
            _thisTransform = transform;
            _duration = 4f;
        }
    }

    private void OnDisable()
    {
        DiactivateElement();
    }

    private void OnTriggerEnter(Collider other)
    {
        CollisionHappened?.Invoke(_effectPoint);
        if (other.TryGetComponent(out Health health))
        {
            health.TakeDamage(_damageValue);
        }
        Deactivate();
    }
}
