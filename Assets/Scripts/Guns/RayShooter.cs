using System.Collections;
using UnityEngine;

public class RayShooter : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private ShotEffect _shotEffectPrefab;

    private Coroutine _coroutine;
    private bool _isRecharging = false;
    private float _delay = 1f;

    public void Fire()
    {
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit) && !_isRecharging)
        {
            Vector3 aimPosition = hit.point;

            _coroutine = StartCoroutine(SphereInicatorCoroutine(aimPosition));
        }
    }

    private IEnumerator SphereInicatorCoroutine(Vector3 pos)
    {
        _isRecharging = true;
        WaitForSeconds delay = new(_delay);

        ShotEffect effect = Instantiate(_shotEffectPrefab, pos, Quaternion.identity);

        yield return delay;

        _isRecharging = false;
    }
}
