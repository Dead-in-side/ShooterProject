using UnityEngine;

[RequireComponent(typeof(Mover), typeof(InputReader), typeof(GravityShifter))]
[RequireComponent(typeof(Health))]
public class Player : MonoBehaviour
{
    [SerializeField] private Rotator _cameraRotator;

    private InputReader _inputReader;
    private Mover _mover;
    private GravityShifter _gravityShifter;
    private Health _health;

    private Vector3 _startPosition;

    private void Awake()
    {
        _gravityShifter = GetComponent<GravityShifter>();
        _mover = GetComponent<Mover>();
        _inputReader = GetComponent<InputReader>();
        _health = GetComponent<Health>();

        _startPosition= transform.position;
    }

    private void OnEnable()
    {
        _inputReader.MoveButtonPressed += _mover.Move;
        _inputReader.JumpButtonPressed += _mover.Jump;
        _inputReader.MouseXMovementHappened += _cameraRotator.RotateX;
        _inputReader.MouseYMovementHappened += _cameraRotator.RotateY;
        _inputReader.ChangeTheGravity += _gravityShifter.SetGravityDirection;

        _health.HealthEnd += Die;
    }

    private void OnDisable()
    {
        _inputReader.MoveButtonPressed -= _mover.Move;
        _inputReader.JumpButtonPressed -= _mover.Jump;
        _inputReader.MouseXMovementHappened -= _cameraRotator.RotateX;
        _inputReader.MouseYMovementHappened -= _cameraRotator.RotateY;
        _inputReader.ChangeTheGravity -= _gravityShifter.SetGravityDirection;
        
        _health.HealthEnd -= Die;
    }

    public void TakeDamage(float damage)
    {
        _health.TakeDamage(damage);
    }

    private void Die()
    {
        transform.position = _startPosition;
        _health.Reborn();
        _gravityShifter.Die();
    }
}
