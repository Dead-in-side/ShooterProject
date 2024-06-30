using UnityEngine;

public class Shooter : Enemy
{
    [SerializeField] private EnemyBullet _bulletPrefab;

    public override void Attack()
    {
       EnemyBullet bullet = Instantiate( _bulletPrefab,transform.position,transform.rotation );

        bullet.SetDamage(Damage);
    }
}

