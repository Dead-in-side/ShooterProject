using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Teleport : MonoBehaviour
{
    [SerializeField] private Transform _target;

    private Collider _platformCollider;

    private void Awake()
    {
        _platformCollider = GetComponent<Collider>();

        _platformCollider.isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Player player))
        {
            player.transform.position = _target.position;
        }
    }
}
