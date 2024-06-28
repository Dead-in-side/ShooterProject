using UnityEngine;

[RequireComponent(typeof(Mover), typeof(InputReader), typeof(GravityShifter))]
public class Player : MonoBehaviour
{
    [SerializeField] private Rotator _cameraRotator;

    private InputReader _inputReader;
    private Mover _mover;
    private GravityShifter _gravityShifter;

    private void Awake()
    {
        _gravityShifter = GetComponent<GravityShifter>();
        _mover = GetComponent<Mover>();
        _inputReader = GetComponent<InputReader>();
    }

    private void OnEnable()
    {
        _inputReader.MoveButtonPressed += _mover.Move;
        _inputReader.JumpButtonPressed += _mover.Jump;
        _inputReader.MouseXMovementHappened += _cameraRotator.RotateX;
        _inputReader.MouseYMovementHappened += _cameraRotator.RotateY;
        _inputReader.ChangeTheGravity += _gravityShifter.SetGravityDirection;
    }

    private void OnDisable()
    {
        _inputReader.MoveButtonPressed -= _mover.Move;
        _inputReader.JumpButtonPressed -= _mover.Jump;
        _inputReader.MouseXMovementHappened -= _cameraRotator.RotateX;
        _inputReader.MouseYMovementHappened -= _cameraRotator.RotateY;
        _inputReader.ChangeTheGravity -= _gravityShifter.SetGravityDirection;
    }
}
