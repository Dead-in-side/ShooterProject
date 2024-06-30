using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] private float _speed;

    private float _lifeTime = 5f;
    private float _currentLifeTIme = 0;
    private float _damage;

    private void Update()
    {
        Move();

        _currentLifeTIme += Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            player.TakeDamage(_damage);
        }

        Destroy(gameObject);
    }

    private void Move()
    {
        Vector3 direction = transform.forward * _speed * Time.deltaTime;
        transform.position += direction;

        if (_currentLifeTIme >= _lifeTime)
        {
            Destroy(gameObject);
        }
    }

    public void SetDamage(float damage) => _damage = damage;
}
