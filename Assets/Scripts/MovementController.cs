using UnityEngine;
using Zenject;

public class MovementController : MonoBehaviour
{
    private Rigidbody _rigidbody;

    private InputListener _input;

    [Header("Wheels")]
    [SerializeField] private WheelCollider[] _leftWheels;
    [SerializeField] private WheelCollider[] _rightWheels;

    [Header("Engine settings")]
    [SerializeField] private float _enginePower;
    [SerializeField] private float _rotateSpeed;

    [Inject]
    public void Construct(InputListener inputListener)
    {
        _input = inputListener;
    }

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        if (_input == null)
            _input = FindObjectOfType<InputListener>();
    }


    void Update()
    {
        Move(_input.Accel);
        Rotate(_input.Rotate);
    }


    private void Move(float accel)
    {
        for (int i = 0; i < _leftWheels.Length; i++)
        {
            _leftWheels[i].motorTorque = _enginePower * accel;
            _rightWheels[i].motorTorque = _enginePower * accel;
        }
    }

    private void Rotate(float rotateInput)
    {
        Quaternion rotateAngle = Quaternion.Euler(0, rotateInput * _rotateSpeed * Time.deltaTime, 0);
        Quaternion currentAngle = _rigidbody.rotation * rotateAngle;
        _rigidbody.MoveRotation(currentAngle);
    }

}
