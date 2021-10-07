using UnityEngine;

public class MiniGunCollisionEffectPool : BasePool<ShootEffect>
{
    private PoolMono<ShootEffect> _pool;

    private void Start()
    {
        _pool = new PoolMono<ShootEffect>(_poolObject, _poolCount, this.transform);
        _pool.AutoExpand = _autoExpand;
    }

    public void ActivateElement(Vector3 hitPoint, Quaternion rotation)
    {
        var effect = _pool.GetFreeElement();
        effect.transform.position = hitPoint;
        effect.transform.rotation = rotation;
    }

    public MiniGunCollisionEffectPool CreatePool()
    {
        MiniGunCollisionEffectPool pool = Instantiate(this);
        return pool;
    }
}
