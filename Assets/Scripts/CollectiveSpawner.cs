using UnityEngine;
using System.Collections;

public class CollectiveSpawner : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    [SerializeField] float spawnTime;
    [SerializeField] float speed = 2f;
    [SerializeField] LayerMask enemyLayer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(CollectSpawner());
    }

    public void LvlUp()
    {
        spawnTime -= 0.1f;
    }

    IEnumerator CollectSpawner()
    {
        while(true)
        {
            Vector2 spawn;
            Vector2 dir;

            //do
            //{
                spawn = Random.insideUnitCircle.normalized * 15f;
                dir = (Vector2.zero - spawn).normalized; 
            //    yield return new WaitForEndOfFrame();
            //} while (Physics2D.Raycast(spawn, dir, 15f, enemyLayer));

            GameObject obj = Instantiate(prefab, spawn, Quaternion.identity);

            obj.GetComponent<Rigidbody2D>().linearVelocity = dir * speed;
            yield return new WaitForSeconds(spawnTime);
        }
    }
}
