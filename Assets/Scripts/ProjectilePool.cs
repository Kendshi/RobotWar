using UnityEngine;

public class ProjectilePool : BasePool<Projectile>
{
    private PoolMono<Projectile> _pool;

    private void Start()
    {
        _pool = new PoolMono<Projectile>(_poolObject, _poolCount, this.transform);
        _pool.AutoExpand = _autoExpand;
    }

    public override void ActivatePoolElement()
    {
        var effect = _pool.GetFreeElement();
        effect.transform.position = _startPosition.position;
        effect.transform.rotation = _rotate.rotation;
    }

    public ProjectilePool CreatePool(Transform tower, Transform effectStartPosition)
    {
        ProjectilePool pool = Instantiate(this);
        pool._rotate = tower;
        pool._startPosition = effectStartPosition;

        return pool;
    }
}
