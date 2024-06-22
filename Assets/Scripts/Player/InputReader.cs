using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const string Horizontal = "Horizontal";
    private const string Vertical = "Vertical";
    private const string MouseX = "Mouse X";

    public event Action<Vector3> MoveButtonPressed;
    public event Action<float> MouseMovementHappened;
    public event Action ZeroMouseButtomPressed;

    private Vector3 _direction;
    private float _directionX;
    private float _directionZ;

    private void Update()
    {
        _directionX = Input.GetAxis(Horizontal);
        _directionZ = Input.GetAxis(Vertical);
        _direction = new Vector3(_directionX,0, _directionZ);

        MoveButtonPressed?.Invoke(_direction);

        MouseMovementHappened?.Invoke(Input.GetAxisRaw(MouseX));

        if (Input.GetMouseButtonDown(0))
        {
            ZeroMouseButtomPressed?.Invoke();
        }
    }
}