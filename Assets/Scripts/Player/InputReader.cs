using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const string Horizontal = "Horizontal";
    private const string Vertical = "Vertical";
    private const string MouseX = "Mouse X";
    private const string MouseY = "Mouse Y";
    private const string Jump = "Jump";

    public event Action<float,float> MoveButtonPressed;
    public event Action<float> MouseXMovementHappened;
    public event Action<float> MouseYMovementHappened;
    public event Action ZeroMouseButtomPressed;
    public event Action JumpButtonPressed;

    private Vector3 _direction;
    private float _directionX;
    private float _directionZ;

    private void Update()
    {
        _directionX = Input.GetAxis(Horizontal);
        _directionZ = Input.GetAxis(Vertical);

        MoveButtonPressed?.Invoke(_directionX,_directionZ);

        MouseXMovementHappened?.Invoke(Input.GetAxisRaw(MouseX));
        MouseYMovementHappened?.Invoke(Input.GetAxisRaw(MouseY));

        if (Input.GetMouseButtonDown(0))
        {
            ZeroMouseButtomPressed?.Invoke();
        }
        if (Input.GetButtonDown(Jump))
        {
            JumpButtonPressed?.Invoke();
        }
    }
}