using UnityEngine;
using System;
using System.Collections;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField] GameObject particle;
    [SerializeField] string enemyType;
    [SerializeField] Transform shootingPoint;
    [SerializeField] float fireRate = 1f;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] SoundMgr soundMgr;
    private GameObject player;
    private GameObject lvlUpMenu;

    public Vector3 targetPos;
    private bool isShooting = false;

    Vector2 velocity = Vector2.zero;


    private GameObject bullet;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        //lvlUpMenu = player.GetComponent<Player>().lvlUpMenu;

        Vector2 dir = (player.transform.position - transform.position).normalized;
        var q = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, q + 180f);


    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position != targetPos)
        {
            transform.position = Vector2.SmoothDamp(transform.position, targetPos, ref velocity, 0.5f);
        }
        else if(!isShooting)
        {
            StartCoroutine(Shooting());
            isShooting = true;
        }
    }

    IEnumerator Shooting()
    {
        while (true)
        {
            if(true)
            {
                bullet = Instantiate(bulletPrefab, shootingPoint.position, Quaternion.identity);
                bullet.GetComponent<Bullet>().SetType(enemyType);
                yield return new WaitForSeconds(1f / fireRate);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Bullet"))
        {
            ScoreCounter.AddScore(25);
            ScoreCounter.enemiesKilled++;
            GameObject.FindGameObjectWithTag("Sound").GetComponent<SoundMgr>().PlaySFX(5);
            Instantiate(particle, transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
