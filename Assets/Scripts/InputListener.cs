using System;
using UnityEngine;

public class InputListener : MonoBehaviour
{
    public float Accel { get { return _accel; } }
    public float Rotate { get { return _rotate; } }
    public static RaycastHit Hit { get; private set; }

    private float _accel;
    private float _rotate;
    private Camera _mainCamera;
    private RaycastHit _hit;

    public static event Action Fire;
    public static event Action<Ray> AlternativeFire;

    private void Start()
    {
        _mainCamera = Camera.main;
    }

    private void Update()
    {
        _accel = Input.GetAxis("Vertical");
        _rotate = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Fire1"))
        {
            Fire?.Invoke();
        }

        Ray cameraRay = _mainCamera.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(cameraRay, out _hit);
        Hit = _hit;

        if (Input.GetButton("Fire2"))
        {
            AlternativeFire?.Invoke(cameraRay);
        }
    }
}
