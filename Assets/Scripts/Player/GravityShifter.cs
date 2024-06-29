using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class GravityShifter : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private Vector3[] _gravityDirections;
    private float _gravityScale = 9.8f;
    private int _currentGravityIndex;
    private float _rotateCounter = 1.2f;
    private float _rotateAngle = 180f;
    private Coroutine _coroutine;
    private bool _coroutineAwake = false;

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
        _rigidbody.AddForce(_gravityScale * _gravityDirections[_currentGravityIndex] * Time.deltaTime, ForceMode.Impulse);
    }

    public void SetGravityDirection()
    {
        if (!_coroutineAwake)
        {
            _currentGravityIndex = ++_currentGravityIndex % _gravityDirections.Length;

            if (_gravityDirections[_currentGravityIndex] == Vector3.up)
            {
                _coroutine = StartCoroutine(RotateGravityCoroutine(_rotateAngle));
            }
            else
            {
                _coroutine = StartCoroutine(RotateGravityCoroutine(_rotateAngle));
            }
        }
    }

    private IEnumerator RotateGravityCoroutine(float angle)
    {
        _coroutineAwake = true;

        float time = 0;

        Vector3 rotation = transform.eulerAngles;

        while (time <= _rotateCounter)
        {
            float delta = angle / _rotateCounter;

            rotation.z += delta * Time.deltaTime;
            transform.rotation = Quaternion.Euler(rotation);

            time += Time.deltaTime;

            yield return null;
        }

        _coroutineAwake = false;
    }
}