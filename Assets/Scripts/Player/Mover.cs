using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed = 1500f;
    [SerializeField] private float _jumpForce = 400f;

    private Rigidbody _rigidbody;
    private bool _isGrounded = true;
    private bool _isJump = false;
    private Vector3 _direction;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        _direction *= Time.deltaTime * _speed;
        _direction = transform.TransformDirection(_direction);

        transform.position +=_direction*Time.fixedDeltaTime ;

        if (_isGrounded && _isJump)
        {
            _rigidbody.AddForce(transform.up * _jumpForce);

            _isGrounded = false;
            _isJump = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Ground>(out _))
        {
            _isGrounded = true;
        }
    }

    public void Move(float directionX, float directionZ)
    {
        _direction = new Vector3(directionX, 0, directionZ);
    }

    public void Jump()
    {
        if (_isGrounded)
        {
            _isJump = true;
        }
    }

}
