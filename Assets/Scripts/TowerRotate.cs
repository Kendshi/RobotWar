using UnityEngine;

public class TowerRotate : MonoBehaviour
{
    [SerializeField] private float _turretRotationSpeed = 5;
    private Transform _tower;
    private Quaternion _lookRotation;

    private void Start()
    {
        _tower = transform;
    }

    private void Update()
    {
        _lookRotation = Quaternion.LookRotation((new Vector3(InputListener.Hit.point.x, 0, InputListener.Hit.point.z) -
            new Vector3(_tower.position.x, 0, _tower.position.z)).normalized);
    }

    private void FixedUpdate()
    {
        _tower.rotation = Quaternion.Slerp(_tower.rotation, _lookRotation, _turretRotationSpeed * Time.fixedDeltaTime);
    }
}
