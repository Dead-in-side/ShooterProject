using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class Enemy : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private float _health;
    private float _speed;

    private Coroutine _coroutine;

    public float Damage { get; private set; }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<Player>(out _))
        {
            StopCoroutine(_coroutine);
            _coroutine = StartCoroutine(AttackCoroutine());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Player player))
        {
            StopCoroutine(_coroutine);
            _coroutine = StartCoroutine(MoveCoroutine(player.transform));
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            MiliAttack(player);
        }
    }

    public void TakeDamage(float damage)
    {
        _health -= damage;

        if (_health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        StartCoroutine(DieCoroutine());
    }

    public void Initialize(float health, float speed, float damage, Transform target)
    {
        _health = health;
        Damage = damage;
        _speed = speed;

        _coroutine = StartCoroutine(MoveCoroutine(target));
    }

    public void MiliAttack(Player player)
    {
        player.TakeDamage(Damage);
    }

    public abstract void Attack();

    public IEnumerator MoveCoroutine(Transform target)
    {
        bool isWork = true;

        while (isWork)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);

            transform.LookAt(target);

            yield return null;
        }

        Attack();
    }

    public IEnumerator AttackCoroutine()
    {
        WaitForSeconds delay = new(2);

        bool isWork = true;

        while (isWork)
        {
            Attack();

            yield return delay;
        }
    }

    private IEnumerator DieCoroutine()
    {
        float waitSecond = 1;

        _rigidbody.freezeRotation = false;
        _rigidbody.AddForce(-transform.forward * 400);

        yield return new WaitForSeconds(waitSecond);

        Destroy(gameObject);
    }
}
