using UnityEngine;
using System.Collections;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField] float fireRate = 1f;
    [SerializeField] GameObject bulletPrefab;
    private GameObject player;

    private GameObject bullet;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //if (bullet == null)
            //bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
    }

    IEnumerator Shooting()
    {
        Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(1f / fireRate);

    }
}
