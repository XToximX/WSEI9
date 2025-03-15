using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyMgr : MonoBehaviour
{
    [SerializeField] float spawnDelay = 5f;
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
                var hit = Physics2D.OverlapCircle(enemyPos, 1f);

                if (hit == null)
                    break;

                yield return new WaitForEndOfFrame();
            }

            //print((int)Mathf.Floor(Random.Range(0f, (float)enemyList.Count - 0.01f)));
            Instantiate(enemyList[(int)Mathf.Floor(Random.Range(0f, (float)enemyList.Count - 0.1f))], enemyPos, Quaternion.identity);
        
            yield return new WaitForSeconds(spawnDelay);
        }
    }
}
