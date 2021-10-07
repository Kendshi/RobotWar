using UnityEngine;

public class CollisionEffectPool : BasePool<ShootEffect>
{
    private PoolMono<ShootEffect> _pool;

    private void Start()
    {
        _pool = new PoolMono<ShootEffect>(_poolObject, _poolCount, this.transform);
        _pool.AutoExpand = _autoExpand;
        Projectile.CollisionHappened += ActivateElement;
    }

    public void ActivateElement(Transform projectile)
    {
        var effect = _pool.GetFreeElement();
        effect.transform.position = projectile.position;
        effect.transform.rotation = projectile.rotation;
    }

    public CollisionEffectPool CreatePool()
    {
        CollisionEffectPool pool = Instantiate(this);
        return pool;
    }
}
