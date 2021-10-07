using UnityEngine;
using Zenject;

public class TracksAnimation : MonoBehaviour
{
    [SerializeField] private Animator _leftTrackAnimator;
    [SerializeField] private Animator _rightTrackAnimator;
    [SerializeField] private WheelCollider[] _wheels;
    private InputListener _input;

    [Inject]
    private void Construct(InputListener inputListener)
    {
        _input = inputListener;
    }

    private void Start()
    {
        //_input = GetComponent<InputListener>();
    }

    private void Update()
    {
        if (_wheels[0].motorTorque > 0)
            SetTrackAnimations(true, false, true, false);

        else if (_wheels[0].motorTorque < 0)
            SetTrackAnimations(false, true, false, true);

        else
            SetTrackAnimations(false, false, false, false);

        if (_wheels[0].motorTorque == 0 && _input.Rotate < 0)
            SetTrackAnimations(false, true, true, false);

        else if (_wheels[0].motorTorque == 0 && _input.Rotate > 0)
            SetTrackAnimations(true, false, false, true);
    }

    private void SetTrackAnimations(bool forwardLeftTrack, bool backLeftTrack, bool forwardRightTrack, bool backRightTrack)
    {
        _leftTrackAnimator.SetBool("Forward", forwardLeftTrack);
        _leftTrackAnimator.SetBool("Back", backLeftTrack);
        _rightTrackAnimator.SetBool("Forward", forwardRightTrack);
        _rightTrackAnimator.SetBool("Back", backRightTrack);
    }
}
