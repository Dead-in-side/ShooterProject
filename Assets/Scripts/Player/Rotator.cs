using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private float _rotateSpeed = 300f;
    [SerializeField] private Camera _camera;

    private Vector3 _rotateAxisY = Vector3.up;
    private Vector3 _rotateAxisX = Vector3.left;
    private float _rotateAngleMax = 90f;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void RotateX(float direction) => transform.Rotate(_rotateAxisY, direction * _rotateSpeed * Time.deltaTime);

    public void RotateY(float direction)
    {
        float rotationY = direction * _rotateSpeed * Time.deltaTime;

        Quaternion yQuaternion = Quaternion.AngleAxis(rotationY, Vector3.left);
        Quaternion temp = _camera.transform.localRotation * yQuaternion;

        if (Quaternion.Angle(Quaternion.identity, temp) < _rotateAngleMax)
        {
            _camera.transform.localRotation = temp;
        }
    }
}
