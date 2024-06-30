using System.Collections;
using UnityEngine;

[RequireComponent(typeof(SpawnTrigger))]
public class EnemiesSpawner : MonoBehaviour
{
    [SerializeField] Enemy _enemyPrefab;
    [SerializeField] float _enemyHealth;
    [SerializeField] float _enemySpeed;
    [SerializeField] float _enemyDamage;

    private SpawnTrigger _spawnTrigger;
    private Coroutine _coroutine;

    private void Awake()
    {
        _spawnTrigger = GetComponent<SpawnTrigger>();
    }

    private void OnEnable()
    {
        _spawnTrigger.PlayerEnterInTriggerZone += StartSpawn;
        _spawnTrigger.PlayerExitTriggerArea += StopSpawn;
    }

    private void OnDisable()
    {
        _spawnTrigger.PlayerEnterInTriggerZone -= StartSpawn;
        _spawnTrigger.PlayerExitTriggerArea -= StopSpawn;
    }

    private void StartSpawn(Player player)
    {
        _coroutine = StartCoroutine(SpawnEnemies(player.transform));
    }

    private void StopSpawn() => StopCoroutine(_coroutine);

    private IEnumerator SpawnEnemies(Transform target)
    {
        WaitForSeconds delay = new(4);

        bool isWork = true;

        while (isWork)
        {
            Spawn(target);

            yield return delay;
        }
    }

    private void Spawn(Transform target)
    {
        Vector3 enemyPosition = RandomPosition();

        Enemy enemy = Instantiate(_enemyPrefab,transform.position + enemyPosition, transform.rotation);
        enemy.Initialize(_enemyHealth, _enemySpeed, _enemyDamage, target);
    }

    private Vector3 RandomPosition()
    {
        float position = 5;

        return new Vector3(Random.Range(-position,position),transform.position.y,Random.Range(-position,position));
    }
}
