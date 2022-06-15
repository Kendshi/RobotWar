using System;
using UnityEngine;

public class InputListener : MonoBehaviour
{
    public float Accel { get { return _accel; } }
    public float Rotate { get { return _rotate; } }
    public static RaycastHit Hit { get; private set; }

    public bool IsStrategyMode;

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
        if (IsStrategyMode)
        {
            StrategyControls();
        }
        else
        {
            ActionControls();
        }
    }

    private void StrategyControls()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Ray cameraRay = _mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(cameraRay, out _hit))
            {
                var hex = _hit.transform.GetComponentInParent<Hex>();
                
                if (hex)
                {
                    hex.ClickOnRightButton();
                }
            }
        }
    }

    private void ActionControls()
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
