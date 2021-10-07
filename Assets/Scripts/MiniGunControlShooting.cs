using UnityEngine;
using System.Collections;

public class MiniGunControlShooting : MonoBehaviour
{
    [SerializeField] private float _damage = 1f;
    [SerializeField] private Transform _shootPosition;
    [SerializeField] private ParticleSystem _muzzle;
    [SerializeField] private Transform _barrel;
    [SerializeField] private MiniGunCollisionEffectPool _effectPool;
    private bool _canNotShoot;

    private void Start()
    {
        InputListener.AlternativeFire += Shoot;
        _effectPool = _effectPool.CreatePool();
    }

    public void Shoot(Ray cameraRay)
    {
        _barrel.RotateAroundLocal(Vector3.forward, 0.04f);
        if (!_canNotShoot)
        {
            _canNotShoot = true;
            RaycastHit hit;
            _muzzle.Play();

            if (Physics.Raycast(cameraRay, out hit, 3000f))
            {
                if (Vector3.Distance(_barrel.position, hit.point) > 15f)
                {
                    Health health = hit.collider.GetComponent<Health>();
                    if (health != null) health.TakeDamage(_damage);
                    _effectPool.ActivateElement(hit.point, hit.transform.rotation);
                }
                else
                {
                    RaycastHit hit2;
                    if (Physics.Raycast(_shootPosition.position, _shootPosition.forward * 300f, out hit2))
                    {
                        _effectPool.ActivateElement(hit2.point, hit2.transform.rotation);
                    }
                }
            }
            StartCoroutine(DelayBetweenShots(0.1f));
        }
    }

    private IEnumerator DelayBetweenShots(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        _canNotShoot = false;
    }

    private void OnDestroy()
    {
        InputListener.AlternativeFire -= Shoot;
    }
}
