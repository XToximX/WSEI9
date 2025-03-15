using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyMgr : MonoBehaviour
{
    public float spawnDelay = 5f;
    [SerializeField] float spawnRange = 5f;

    [SerializeField] List<GameObject> enemyList;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(EnemySpawner());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator EnemySpawner()
    {
        while(true)
        {
            Vector2 enemyPos;
            while(true)
            {
                enemyPos = Random.insideUnitCircle.normalized * spawnRange;
                enemyPos = new Vector2(enemyPos.x * 1.5f, enemyPos.y);

                var hit1 = Physics2D.OverlapCircle(enemyPos, 1f);
                var hit2 = Physics2D.OverlapCircle(enemyPos * 1.2f, 1f);
                var hit3 = Physics2D.OverlapCircle(enemyPos * 1.4f, 1f);

                if (hit1 == null && hit2 == null && hit3 == null)
                    break;

                yield return new WaitForEndOfFrame();
            }

            Vector3 spawnPos = enemyPos * 1.5f;

            //print((int)Mathf.Floor(Random.Range(0f, (float)enemyList.Count - 0.01f)));
            GameObject enemy = Instantiate(enemyList[(int)Mathf.Floor(Random.Range(0f, (float)enemyList.Count - 0.1f))], spawnPos, Quaternion.identity);
            enemy.GetComponent<EnemyShoot>().targetPos = enemyPos;

            yield return new WaitForSeconds(spawnDelay);
        }
    }
}
