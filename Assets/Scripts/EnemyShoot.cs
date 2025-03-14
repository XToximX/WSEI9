using UnityEngine;
using System.Collections;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField] string enemyType;
    [SerializeField] Transform shootingPoint;
    [SerializeField] float fireRate = 1f;
    [SerializeField] GameObject bulletPrefab;
    private GameObject player;

    private GameObject bullet;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindWithTag("Player");

        Vector2 dir = (player.transform.position - transform.position).normalized;
        var q = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, q - 90f);


        StartCoroutine(Shooting());
    }

    // Update is called once per frame
    void Update()
    {
        //if (bullet == null)
            //bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
    }

    IEnumerator Shooting()
    {
        while (true)
        {
            bullet = Instantiate(bulletPrefab, shootingPoint.position, Quaternion.identity);
            bullet.GetComponent<Bullet>().SetType(enemyType);
            yield return new WaitForSeconds(1f / fireRate);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
