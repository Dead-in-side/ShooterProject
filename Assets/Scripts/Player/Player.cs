using UnityEngine;

[RequireComponent(typeof(Mover), typeof(InputReader))]
public class Player : MonoBehaviour
{
    [SerializeField] private Rotator _cameraRotator;

    private InputReader _inputReader;
    private Mover _mover;

    private void Awake()
    {
        _mover = GetComponent<Mover>();
        _inputReader = GetComponent<InputReader>();
    }

    private void OnEnable()
    {
        _inputReader.MoveButtonPressed += _mover.Move;
        _inputReader.MouseMovementHappened += _cameraRotator.Rotate;
    }

    private void OnDisable()
    {
        _inputReader.MoveButtonPressed -= _mover.Move;
        _inputReader.MouseMovementHappened -= _cameraRotator.Rotate;
    }
}