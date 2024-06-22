using UnityEngine;

[RequireComponent (typeof(RayShooter))]
public class Gun : MonoBehaviour
{
    [SerializeField] InputReader _inputReader;

    private RayShooter _rayShooter;

    private void Awake()
    {
        _rayShooter = GetComponent<RayShooter>();
    }

    private void OnEnable()
    {
        _inputReader.ZeroMouseButtomPressed += _rayShooter.Fire;
    }
}
