using System.Collections;
using UnityEngine;

public class RayShooter : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private ShotEffect _shotEffectPrefab;

    private Coroutine _coroutine;
    private bool _isRecharging = false;
    private WaitForSeconds _delay = new(1f);

    public void Fire(float damage)
    {
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit) && !_isRecharging)
        {
            if (hit.collider.TryGetComponent(out Enemy enemy))
            {
                enemy.TakeDamage(damage);
            }
            else if( hit.collider.isTrigger == true)
            {
                
            }
            else
            {
                Vector3 targetPosition = hit.point;

                _coroutine = StartCoroutine(SphereInicatorCoroutine(targetPosition));
            }
        }
    }

    private IEnumerator SphereInicatorCoroutine(Vector3 pos)
    {
        _isRecharging = true;

        ShotEffect effect = Instantiate(_shotEffectPrefab, pos, Quaternion.identity);

        yield return _delay;

        _isRecharging = false;
    }
}
