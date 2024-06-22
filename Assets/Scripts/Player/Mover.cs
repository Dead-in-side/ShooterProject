using UnityEngine;

[RequireComponent (typeof(CharacterController))]
public class Mover : MonoBehaviour
{
    private float _speed;
    private float _gravity = -9.8f;
    private CharacterController _playerCharacterController;

    private void Awake()
    {
        _playerCharacterController = GetComponent<CharacterController> ();
        _speed = 20f;
    }

    public void Move(Vector3 direction)
    {
        direction *= _speed * Time.deltaTime; 
        direction.y = _gravity;
        direction = transform.TransformDirection(direction);

        _playerCharacterController.Move(direction);
    }
}
