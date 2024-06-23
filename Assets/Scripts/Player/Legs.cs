using System;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Legs : MonoBehaviour
{
    public event Action GroundedIsChange;

    private void OnTriggerEnter(Collider other)
    {
        GroundedIsChange?.Invoke();
    }
}
