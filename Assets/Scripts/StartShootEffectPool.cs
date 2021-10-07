using UnityEngine;

public class StartShootEffectPool : BasePool<ShootEffect>
{
    private PoolMono<ShootEffect> _pool;

    private void Start()
    {
        _pool = new PoolMono<ShootEffect>(_poolObject, _poolCount, this.transform);
        _pool.AutoExpand = _autoExpand;
    }

    public override void ActivatePoolElement()
    {
        var effect = _pool.GetFreeElement();
        effect.transform.position = _startPosition.position;
        effect.transform.rotation = _rotate.rotation;
    }

    public StartShootEffectPool CreatePool(Transform tower, Transform effectStartPosition)
    {
        StartShootEffectPool pool = Instantiate(this);
        pool._rotate = tower;
        pool._startPosition = effectStartPosition;

        return pool;
    }
}
