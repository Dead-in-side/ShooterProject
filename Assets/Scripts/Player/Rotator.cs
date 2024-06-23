using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private float _rotateSpeed = 300f;

    private Vector3 _rotateAxis = Vector3.up;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void Rotate(float direction) => transform.Rotate(_rotateAxis, direction * _rotateSpeed * Time.deltaTime);
}
