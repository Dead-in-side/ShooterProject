using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class GravityShifter : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private Vector3[] _gravityDirections;
    private float _gravityScale = 9.8f;
    private int _currentGravityIndex;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();

        _gravityDirections = new Vector3[]
        {
            Vector3.down,
            Vector3.up
        };

        _rigidbody.useGravity = false;

        _currentGravityIndex = 0;
    }

    private void FixedUpdate()
    {
        _rigidbody.AddForce(_gravityScale * _gravityDirections[_currentGravityIndex]*Time.deltaTime, ForceMode.Impulse);
    }

    public void SetGravityDirection()
    {
        _currentGravityIndex = ++_currentGravityIndex % _gravityDirections.Length;

        if (_gravityDirections[_currentGravityIndex] == Vector3.up)
        {
            RotateGravity(180);
        }
        else
        {
            RotateGravity(0);
        }
    }

    private void RotateGravity(float angle)
    {
        Vector3 rotation = transform.eulerAngles;
        rotation.z = angle;
        transform.rotation = Quaternion.Euler(rotation);
    }
}