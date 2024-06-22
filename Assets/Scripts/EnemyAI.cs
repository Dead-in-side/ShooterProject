using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float Speed;
    public float ObstacleRande;
    public bool Alive = true;
    [SerializeField] private GameObject[] _fireballsPrefab;
    private GameObject _fireball;

    void Start()
    {
        Alive = true;
    }

    void Update()
    {
        if (Alive)
        {
            transform.Translate(0, 0, Speed * Time.deltaTime);

            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                GameObject hitObject = hit.transform.gameObject;

                if (hitObject.GetComponent<CharacterController>())
                {
                    if (_fireball == null)
                    {
                        int randFireball = Random.Range(1, _fireballsPrefab.Length);
                        _fireball = Instantiate(_fireballsPrefab[randFireball]) as GameObject;
                        _fireball.transform.position = transform.TransformPoint(Vector3.forward * 1.5f);
                        _fireball.transform.rotation = transform.rotation;
                    }
                    else if (hit.distance < ObstacleRande)
                    {
                        float angleRotation = Random.Range(-100, 100);
                        transform.Rotate(0, angleRotation, 0);
                    }
                }
            }
        }
    }

    public void SetAlive(bool alive)
    {
        Alive = alive;
    }
}
