using System;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class SpawnTrigger : MonoBehaviour
{
    public event Action<Player> PlayerEnterInTriggerZone;
    public event Action PlayerExitTriggerArea;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            PlayerEnterInTriggerZone?.Invoke(player);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            PlayerExitTriggerArea?.Invoke();
        }
    }
}
