using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour
{
    private EnemyAI AI;

    void Start()
    {
        AI = GetComponent<EnemyAI>();
    }

    public void ReactToHit()
    {
        if (AI != null)
        {
            AI.SetAlive(false);
            StartCoroutine(DieCoroutine(3));
        }
    }

    private IEnumerator DieCoroutine(float waitSecond)
    {
        this.transform.Rotate(45, 0, 0);

        yield return new WaitForSeconds(waitSecond);

        Destroy(this.transform.gameObject);
    }
}
